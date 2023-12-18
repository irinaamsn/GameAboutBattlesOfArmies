using GameAboutBattlesOfArmies.BL.Bridge;
using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Contracts.SA;
using GameAboutBattlesOfArmies.BL.Controller;
using GameAboutBattlesOfArmies.BL.Controller.Decorator.SADecorator;
using GameAboutBattlesOfArmies.BL.Controller.Factory;
using GameAboutBattlesOfArmies.BL.Controller.LazyClass;
using GameAboutBattlesOfArmies.BL.Controller.Proxy;
using GameAboutBattlesOfArmies.BL.Controlller.Exceptions;
using GameAboutBattlesOfArmies.BL.Models;
using GameAboutBattlesOfArmies.BL.Models.Factory;
using GameAboutBattlesOfArmies.BL.Models.Unit;

namespace GameAboutBattlesOfArmies.BL.Controlller
{
    public class ArmieController
    {
        public string id = Guid.NewGuid().ToString();
        readonly IDataSaver manager;
        readonly ArmieCreator _creator;
        public Armie armie;
        public int ArmiePrice { get; set; }
        public ArmieController()//WinForm
        {
            armie = new Armie();
            //armie.ArmiePrice = price;
            //ArmiePrice = price;
            manager = new LazySerialisableSaver();
            _creator = new ArmieCreator();
        }
        public ArmieController(int price)
        {   
            armie = new Armie();
            armie.ArmiePrice = price;
            ArmiePrice = price;
            manager = new LazySerialisableSaver();
            _creator = new ArmieCreator();
        }
        public Armie GetArmie(int price)
        {
            //CreatorUnit creatorUnit = null;
            //creatorUnit = _creator.CreateUnitToArmie(new FactoryProxy(new UnitFactory()),creatorUnit);
            var unit = _creator.CreateUnitToArmie(new FactoryProxy(new UnitFactory()), armie);
            AddUnit(unit);
            price-=unit.UnitPrice;
            //unit.ArmiePrice = ArmiePrice;
            unit.MyArmie = armie;
            while (price > 0)
            {
                //var b = false;
                var factory = _creator.CreateFactoryToArmie();  
                //if (b) factory = new BufFactory();
                //creatorUnit.SetFactory(factory);//set new factory without new obj
                //creatorUnit = _creator.CreateUnitToArmie(new FactoryProxy(factory), creatorUnit);
                var unitSA = _creator.CreateUnitToArmie(new FactoryProxy(factory), armie);
               // unitSA.ArmiePrice = ArmiePrice;
                unitSA.MyArmie = armie;
                AddUnit(unitSA);
                //if (unitSA.UnitName == "Heavy") b = true;
                price -= unitSA.UnitPrice;
            }
            //armie.AllUnits[0] = new UnitLoggingProxy(new HeavyInfantry());
            //armie.AllUnits[0].ArmiePrice = ArmiePrice;
            //armie.AllUnits[1] = new UnitLoggingProxy(new UnitBufDecorator(new LightInfantry()));
            //armie.AllUnits[1].ArmiePrice = ArmiePrice;
            PrintArmie(armie);
            return armie;
        } 
        public void PrintArmie(Armie armie)
        {
            foreach(var item in armie.AllUnits)
            {
                Console.WriteLine($"Name - {item.UnitName} | HP - {item.HitPoints} |"); Console.WriteLine();
            }
            Console.WriteLine();
        }
        public void AddUnit(IUnit unit)
        {
            try
            {
                int unitPrice = armie.AllUnits.Sum(x => x.UnitPrice);
                               
                if (unitPrice+unit.UnitPrice <= ArmiePrice)
                {
                    var unitSA = unit?.IsSpecialAbility();
                    if (unitSA is UnitDecoratorBase)
                    {
                        if (armie.AllUnits.Count == 0) throw new ArmieException("Нельзя добавить первым юнита со специальной возможностью");//TODO
                        //var unitSA = (UnitDecoratorBase)unit;
                       
                        if (!armie.UnitSADescriptions.Any(x => x.SpecialAbilityRange == unitSA.SpecialAbilityRange && x.SpecialAbilityType == unitSA.SpecialAbilityType)) armie.UnitSADescriptions.Add(unitSA);
                    }
                     else if (!armie.UnitDescriptions.Any(x => x.UnitDescriptionId == unit.UnitDescriptionId)) armie.UnitDescriptions.Add(unit);
                
                    armie.Units.Add(unit.UnitDescriptionId);
                    armie.AllUnits.Add(unit);

                }
            }
            catch (ArmieException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message} ");
            }
        }
        public void Save(Armie armie)
        {
            manager.Save(armie);
        }
    }
}

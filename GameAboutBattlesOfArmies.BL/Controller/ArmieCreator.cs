using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Controller.Factory;
using GameAboutBattlesOfArmies.BL.Controlller.Factory;
using GameAboutBattlesOfArmies.BL.Models.Factory;
using GameAboutBattlesOfArmies.BL.Bridge;
using GameAboutBattlesOfArmies.BL.Enums;
using GameAboutBattlesOfArmies.BL.Controller.Bridge;
using GameAboutBattlesOfArmies.BL.Models;

namespace GameAboutBattlesOfArmies.BL.Controller
{
    public class ArmieCreator
    {
        public int GetUnitID()
        {
            var rnd = new Random();
            var unit = rnd.Next(1,Enum.GetNames(typeof(EnumUnitID)).Length+1);//unit//TODO+1
            return unit;
        }
        public int GetFactoryType()
        {
            var rnd = new Random();
           // var count = Enum.GetNames(typeof(EnumSAType)).Where(x=>x.Equals(priority)).ToArray();
            var factory = rnd.Next(1, Enum.GetNames(typeof(EnumSAType)).Length+1);//unit
            //var sa = rnd.Next(Enum.GetNames(typeof(EnumSAType)).Length);//sa
            return factory;
        }
        public IUnit CreateUnitToArmie(IFactory factory, Armie armie )
        {
            CreatorUnit creatorUnit = null;
            var id = GetUnitID();
            if (id == 1) creatorUnit = new CreateKnight(factory);
            if (id == 2) creatorUnit = new CreatorHeavy(factory);
            if (id == 3) creatorUnit = new CreateLight(factory);
            if (id == 4) creatorUnit = new CreateWalkTheCity(factory);
            return creatorUnit.GetUnit(armie);
        }
        public IFactory CreateFactoryToArmie()
        {
            var type = GetFactoryType();
            IFactory factory = null;
            if (type == 1) factory = new ArcherFactory();
            if (type == 2) factory = new HealerFactory();
            if (type == 3) factory = new WitcherFactory();
            if (type == 4) factory = new BufFactory();
            if (type == 0) factory = new UnitFactory();
            return factory;
        }

        #region Menu
        //public void GetValueFactory(IFactory factory, ArmieController armie)
        //{  
        //    var unit = ChooseListUnits(factory);

        //    IUnit unitNew = null;
        //    if (unit == "1")
        //    {
        //        CreatorUnit creatorUnit =new CreateKnight(factory);
        //        unitNew = creatorUnit.GetUnit();
        //        unitNew.ArmiePrice = armie.ArmiePrice;
        //    }
        //    if (unit == "2")
        //    {
        //        CreatorUnit creatorUnit = new CreatorHeavy(factory);
        //        unitNew = creatorUnit.GetUnit();
        //        //unitNew = factory.CreateHeavy();
        //        unitNew.ArmiePrice = armie.ArmiePrice;
        //    }
        //    if (unit == "3")
        //    {
        //        CreatorUnit creatorUnit = new CreateLight(factory);
        //        unitNew = creatorUnit.GetUnit();
        //        //unitNew = factory.CreateLight();
        //        unitNew.ArmiePrice = armie.ArmiePrice;
        //        //if (unitNew is not ISpecialAbility && armie.armie.AllUnits.Count>0)
        //        //    if (armie.armie.AllUnits[0].UnitName !=unitNew.UnitName) 
        //        //        unitNew = AddDopAbility(unitNew);
        //    }
        //    armie.AddUnit(unitNew);
        //}
        //public IFactory ChooseUnit()
        //{
        //    Console.WriteLine("Вы хотите добавить Unit - 1, Archer -2, Healer -3, Witcher-4, Buf-5?");
        //    var num = Console.ReadLine();
        //    if (num == "2") return new ArcherFactory();
        //    else if (num == "1") return new UnitFactory();
        //    else if (num == "3") return new HealerFactory();
        //    else if (num == "4") return new WitcherFactory();
        //    else if (num == "5") return new BufFactory();
        //    return null;
        //}

        //public string ChooseListUnits(IFactory factory)
        //{
        //    Console.WriteLine("Выберите юнита");
        //    if (factory is not BufFactory)
        //    {
        //        Console.WriteLine("Knight - 1");
        //        Console.WriteLine("HeavyInfactry - 2");
        //        Console.WriteLine("LightInfactry - 3");
        //    }
        //    else
        //    {
        //        Console.WriteLine("LightInfactry - 3");
        //    }

        //    return Console.ReadLine();
        //}
        //public string ChooseDopAbility()
        //{
        //    //Console.WriteLine("Выберите возможность:");
        //    Console.WriteLine("Баф - 1");
        //    Console.WriteLine("Никакую - 2");

        //    return Console.ReadLine();
        //}
        //public IUnit AddDopAbility(IUnit unit)
        //{
        //    var dopAbility = ChooseDopAbility();
        //    if (dopAbility =="1")
        //    {
        //        return new UnitBufDecorator(unit);
        //    }
        //    return unit;
        //}
        #endregion
    }
}

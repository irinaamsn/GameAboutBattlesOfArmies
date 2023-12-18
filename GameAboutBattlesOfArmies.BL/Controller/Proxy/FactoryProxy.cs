using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Controller.Factory;
using GameAboutBattlesOfArmies.BL.Controlller.Factory;
using GameAboutBattlesOfArmies.BL.Enums;
using GameAboutBattlesOfArmies.BL.Models.Factory;
using GameAboutBattlesOfArmies.BL.Models.Unit;

namespace GameAboutBattlesOfArmies.BL.Controller.Proxy
{
    public class FactoryProxy : IFactory
    {
        IFactory factory;
        public FactoryProxy(IFactory factory)
        {
            this.factory = factory;
        }
        public IUnit CreateUnit(IUnit unit)
        {
            if (unit.UnitDescriptionId==(int)EnumUnitID.WalkTheCity)
            {
                factory = new UnitFactory();
                return factory.CreateUnit(unit);
            }
            
            if (factory is BufFactory)
            {
                var light = new LightInfantry();
                light.MyArmie = unit.MyArmie;
                return factory.CreateUnit(light);
            }    
                
            if (factory is ArcherFactory)
                return factory.CreateUnit(unit);
            if (factory is HealerFactory)
                return factory.CreateUnit(unit);
            if (factory is WitcherFactory)
                return factory.CreateUnit(unit);
            
            return factory.CreateUnit(unit);
        }
    }
}

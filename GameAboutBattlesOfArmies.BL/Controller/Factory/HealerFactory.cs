using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Controller.Decorator.SADecorator;
using GameAboutBattlesOfArmies.BL.Controller.Proxy;

namespace GameAboutBattlesOfArmies.BL.Controlller.Factory
{
    public class HealerFactory: IFactory
    {
        public IUnit CreateUnit(IUnit unit)
        {
            var healer = new UnitHealerDecorator(unit);
            return new UnitLoggingProxy(healer);
        }
        public override string ToString()
        {
            return "Healer";
        }
    }
}

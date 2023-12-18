using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Controller.Decorator.SADecorator;
using GameAboutBattlesOfArmies.BL.Controller.Proxy;

namespace GameAboutBattlesOfArmies.BL.Controller.Factory
{
    public class WitcherFactory:IFactory
    {
        public IUnit CreateUnit(IUnit unit)
        {
            var witcher = new UnitWitcherDecorator(unit);
            return new UnitLoggingProxy(witcher);
        }
        public override string ToString()
        {
            return "Witcher";
        }
    }
}

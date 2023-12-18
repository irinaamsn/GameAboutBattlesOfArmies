using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Controller.Decorator.SADecorator;
using GameAboutBattlesOfArmies.BL.Controller.Proxy;

namespace GameAboutBattlesOfArmies.BL.Controller.Factory
{
    public class BufFactory:IFactory
    {
        public IUnit CreateUnit(IUnit unit)
        {
            var buf = new UnitBufDecorator(unit);
            return new UnitLoggingProxy(buf);
        }
    }
}

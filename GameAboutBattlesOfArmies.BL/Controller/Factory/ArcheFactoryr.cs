using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Controller.Decorator.SADecorator;
using GameAboutBattlesOfArmies.BL.Controller.Proxy;


namespace GameAboutBattlesOfArmies.BL.Controlller.Factory
{
    public class ArcherFactory :  IFactory
    {
        public IUnit CreateUnit(IUnit unit)
        {
            var archer = new UnitArcherDecorator(unit);
            return new UnitLoggingProxy(archer);
        }
        public override string ToString()
        {
            return "Archer";
        }
    }
}

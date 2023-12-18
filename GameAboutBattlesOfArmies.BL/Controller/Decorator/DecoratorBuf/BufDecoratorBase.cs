using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Models.Repository;

namespace GameAboutBattlesOfArmies.BL.Controller.Decorator.DecoratorBuf
{
    public class BufDecoratorBase:UnitRepository
    {
        protected readonly IUnit _component;

        public BufDecoratorBase(IUnit component)
        {
            UnitDescriptionId = component.UnitDescriptionId;
            UnitName = "HeavyWithBuf";
            Attack = component.Attack;
            Defence = component.Defence;
            HitPoints = component.HitPoints;
            MyArmie=component.MyArmie;
            _component = component;
        }
        public IUnit GetOriginalHeavy()
        {
            _component.HitPoints = HitPoints;
            return _component;
        }
    }
}

using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Models.Repository;

namespace GameAboutBattlesOfArmies.BL.Controller.Decorator.SADecorator
{
    public class UnitDecoratorBase : UnitRepository
    {
        protected readonly IUnit _component;

        public virtual int SpecialAbilityType { get; }
        public virtual int SpecialAbilityRange { get; }
        public virtual int SpecialAbilityStrength { get; }

        public UnitDecoratorBase(IUnit component)
        {
            UnitDescriptionId = component.UnitDescriptionId;
            Attack = component.Attack;
            Defence = component.Defence;
            HitPoints = component.HitPoints;
          //  ArmiePrice = component.ArmiePrice;
            MyArmie=component.MyArmie;
            _component = component;
        }
        public virtual IUnit DoAction(IUnit unit)
        {
            TryingKill(unit);
            return unit;
        }
    }
}

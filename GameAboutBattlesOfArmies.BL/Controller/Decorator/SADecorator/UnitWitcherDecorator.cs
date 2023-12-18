using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Controller.Proxy;
using GameAboutBattlesOfArmies.BL.Enums;
using GameAboutBattlesOfArmies.BL.Log;

namespace GameAboutBattlesOfArmies.BL.Controller.Decorator.SADecorator
{
    public class UnitWitcherDecorator:UnitDecoratorBase
    {
        LoggerServicesingleton loggerService = LoggerServicesingleton.getInstance();
        public override int SpecialAbilityType => (int)EnumSAType.Witcher;
        public override int SpecialAbilityRange => 2;
        public override int SpecialAbilityStrength => 2;

        public UnitWitcherDecorator(IUnit component) : base(component) { }
        public override string? UnitName { get; set; } = "Witcher";
        public override int UnitPrice => Attack + Defence + HitPoints + (SpecialAbilityRange + SpecialAbilityStrength) * 2;

        public override IUnit DoAction(IUnit unit)
        {
            IUnit clone = null;
            var unitCl = unit.IsClonable();
            if (unitCl != null)
            {
                if (unitCl.CanCloneMe(SpecialAbilityStrength))
                {
                    clone = new UnitLoggingProxy((IUnit)unitCl.Clone());
                    loggerService.WitcherTryDoAction(this, unit, true);
                }
            }
           else loggerService.WitcherTryDoAction(this, unit, false);
            return clone;
        }
        public override string ToString()
        {
            return UnitName;
        }
    }
}

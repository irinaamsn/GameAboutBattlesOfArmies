using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Contracts.SA;
using GameAboutBattlesOfArmies.BL.Enums;
using GameAboutBattlesOfArmies.BL.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAboutBattlesOfArmies.BL.Controller.Decorator.SADecorator
{
    public class UnitHealerDecorator : UnitDecoratorBase, IHealerable
    {
        LoggerServicesingleton loggerService = LoggerServicesingleton.getInstance();
        public override int SpecialAbilityType => (int)EnumSAType.Healer;
        public override int SpecialAbilityRange => 3;
        public override int SpecialAbilityStrength => 5;
        public int MaxHitPoints => (int)EnumMaxHP.Healer;
        public UnitHealerDecorator(IUnit component) : base(component) { }
        public override string? UnitName { get; set; } = "Healer";
        public override int UnitPrice => Attack + Defence + HitPoints + (SpecialAbilityRange + SpecialAbilityStrength) * 2;

        public override IUnit DoAction(IUnit unit)
        {
            var healerableUnit  = unit.IsHealerable();
            if (healerableUnit != null)
            {
                //IHealerable unitH = (IHealerable)unit;
                if (healerableUnit.CanHealMe(unit.HitPoints, SpecialAbilityStrength))
                {
                    unit.HitPoints += SpecialAbilityStrength;
                    loggerService.HealerTryDoAction(this, unit, true);
                    return unit;
                }
                else loggerService.HealerTryDoAction(this, unit, false);
            }
            else loggerService.HealerTryDoAction(this, unit, false);
            return null;
        }
        public override string ToString()
        {
            return UnitName;
        }
    }
}

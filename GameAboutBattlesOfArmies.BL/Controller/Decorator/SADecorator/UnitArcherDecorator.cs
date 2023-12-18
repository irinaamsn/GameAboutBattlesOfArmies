using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Contracts.SA;
using GameAboutBattlesOfArmies.BL.Enums;
using GameAboutBattlesOfArmies.BL.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GameAboutBattlesOfArmies.BL.Controller.Decorator.SADecorator
{
    public class UnitArcherDecorator:UnitDecoratorBase, IHealerable
    {
        LoggerServicesingleton loggerService = LoggerServicesingleton.getInstance();
        public override int SpecialAbilityType => (int)EnumSAType.Archer;
        public override int SpecialAbilityRange => 3;
        public override int SpecialAbilityStrength => 4;
        public int MaxHitPoints => (int)EnumMaxHP.Acher;
        public UnitArcherDecorator(IUnit component) : base(component) { }
        public override string? UnitName { get; set; } = "Archer";
        public override int UnitPrice => Attack + Defence + HitPoints + (SpecialAbilityRange + SpecialAbilityStrength) * 2;

        public override IUnit DoAction(IUnit unit)
        {
            unit.HitPoints -= SpecialAbilityStrength;
            loggerService.ArcherTryDoAction(this, unit);
            return unit;       
        }
        public override string ToString()
        {
            return UnitName;
        }
    }
}

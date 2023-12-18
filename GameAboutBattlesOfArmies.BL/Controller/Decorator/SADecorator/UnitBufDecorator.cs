using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Controller.Decorator.DecoratorBuf;
using GameAboutBattlesOfArmies.BL.Controller.Proxy;
using GameAboutBattlesOfArmies.BL.Enums;
using GameAboutBattlesOfArmies.BL.Log;
using System.Reflection;

namespace GameAboutBattlesOfArmies.BL.Controller.Decorator.SADecorator
{
    public class UnitBufDecorator : UnitDecoratorBase
    {
        LoggerServicesingleton loggerService = LoggerServicesingleton.getInstance();
        public override int SpecialAbilityType => (int)EnumSAType.Buf;
        public override int SpecialAbilityRange => 1;
        public override int SpecialAbilityStrength => 5;
        public UnitBufDecorator(IUnit component) : base(component) { }
        public override string? UnitName { get; set; } = "Buf";
        public override int UnitPrice => Attack + Defence + HitPoints + (SpecialAbilityRange + SpecialAbilityStrength) * 2;

        public override IUnit DoAction(IUnit unit)
        {
            var unitBuf = unit.IsCanWearBuf();
            if (unitBuf != null)
            {
                FieldInfo field = typeof(UnitLoggingProxy).GetField("Unit", BindingFlags.Instance | BindingFlags.NonPublic);
                var fieldUnit = (IUnit)field.GetValue(unit);
                var heavy = new BufDecorator(fieldUnit);
                var buf = heavy.GetBuf(Enum.GetNames(typeof(EnumBufes)).Length);
                if (buf == (int)EnumBufes.Hourse)
                    heavy.Attack += buf;
                else heavy.Defence += buf;
               // heavy.MyArmie = fieldUnit.MyArmie;
                loggerService.BufTryDoAction(this, unit, true);
                return new UnitLoggingProxy(heavy);
            }
           else loggerService.BufTryDoAction(this, unit, false);
            return null;
        }
        public override string ToString()
        {
            return UnitName;
        }
    }
}

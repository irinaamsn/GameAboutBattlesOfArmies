using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Contracts.SA;
using GameAboutBattlesOfArmies.BL.Controller.Decorator.SADecorator;
using GameAboutBattlesOfArmies.BL.Controller.Prototype;
using GameAboutBattlesOfArmies.BL.Log;
using GameAboutBattlesOfArmies.BL.Models;

#nullable disable
namespace GameAboutBattlesOfArmies.BL.Controller.Proxy
{
    public class UnitLoggingProxy : IUnit
    {
        private IUnit Unit;
        LoggerServicesingleton loggerService;

        public int UnitDescriptionId { get; set; }
        public string UnitName { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public Armie MyArmie { get; set; }

        public int HitPoints
        {
            get { return Unit.HitPoints; }
            set
            {
                Unit.HitPoints = value;
                //HitPointsChanged?.Invoke(Unit.HitPoints, Unit);
            }
        }
        public IHealerable IsHealerable() 
        {
            if (Unit is IHealerable healerable )return healerable;            
            return null;

        }
        public IClonable IsClonable()
        {
            if (Unit is IClonable clonable) return clonable;
            return null;

        }
        public UnitDecoratorBase IsSpecialAbility()
        {
            if (Unit is UnitDecoratorBase unitDecorator) return unitDecorator;
            return null;

        }
        public ICanWearBuf IsCanWearBuf()
        {
            if (Unit is ICanWearBuf canWearBuf) return canWearBuf;
            return null;
        }
        public int UnitPrice => Unit.UnitPrice;

        //public event Action<int, IUnit> HitPointsChanged;
        public UnitLoggingProxy(IUnit unit)
        {
            Unit = unit;
            UnitName=unit.UnitName;
            UnitDescriptionId = unit.UnitDescriptionId;
            Attack = unit.Attack;
            Defence = unit.Defence;
            MyArmie=unit.MyArmie;   
            //ArmiePrice = unit.ArmiePrice;
            loggerService = LoggerServicesingleton.getInstance();
        }
        public (bool, IUnit,int) TryingKill(IUnit unit)
        {
            var res =Unit.TryingKill(unit);
            loggerService.ButtleBetweenUnits(Unit, unit, res.Item3);
            if (res.Item1)
            {              
                loggerService.TryTakeOffBuflog(res.Item2);
                return (true, res.Item2,res.Item3);
            }
            return (false, res.Item2,res.Item3);
        }
        public bool Death()
        {
            var isDeath = Unit.Death();
            if (isDeath)
                 loggerService.UnitLeaveBattlefield(Unit);
            return isDeath;
        }
        public override string ToString()
        {
            return UnitName;
        }

        public IClone Clone()
        {
            //FieldInfo field = typeof(UnitLoggingProxy).GetField("Unit", BindingFlags.Instance | BindingFlags.NonPublic);
            //var fieldUnit = (IUnit)field.GetValue(this);
            //fieldUnit.Clone();
            IUnit unit = (IUnit)Unit.Clone();
            var unitClone = new UnitLoggingProxy(unit);
            
            return unitClone;
        }       
    }
}

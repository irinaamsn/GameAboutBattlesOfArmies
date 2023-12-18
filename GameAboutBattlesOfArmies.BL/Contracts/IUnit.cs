using GameAboutBattlesOfArmies.BL.Contracts.SA;
using GameAboutBattlesOfArmies.BL.Controller.Decorator.SADecorator;
using GameAboutBattlesOfArmies.BL.Controller.Prototype;
using GameAboutBattlesOfArmies.BL.Models;

namespace GameAboutBattlesOfArmies.BL.Contracts
{
    public interface IUnit: IClone
    {
        public  int UnitDescriptionId { get; set; }
        public string? UnitName { get; set; }
        public int Attack { get; set; } 
        public int Defence { get; set; }
        public int HitPoints { get; set; }
        public Armie MyArmie { get; set; }
        public (bool, IUnit,int) TryingKill(IUnit unit);

        public int UnitPrice { get; }
        //public event Action<int, IUnit> HitPointsChanged;
        public IHealerable IsHealerable()
        {
            if (this is IHealerable healerable) return healerable;
            return null;

        }
        public IClonable IsClonable()
        {
            if (this is IClonable clonable) return clonable;
            return null;

        }
        public ICanWearBuf IsCanWearBuf()
        {
            if (this is ICanWearBuf canWearBuf) return canWearBuf;
            return null;

        }
        public UnitDecoratorBase IsSpecialAbility()
        {
            if (this is UnitDecoratorBase unitDecorator) return unitDecorator;
            return null;

        }
        public bool Death() => HitPoints <= 0;

    }
}

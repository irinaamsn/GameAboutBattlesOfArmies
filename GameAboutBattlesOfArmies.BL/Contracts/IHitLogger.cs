namespace GameAboutBattlesOfArmies.BL.Contracts
{
    public interface IHitLogger
    {
        public void UnitTryKill();
        public IUnit UnitSATryAction();
        public (bool, IUnit) TryTakeOffBuf(IUnit unit);
    }
}
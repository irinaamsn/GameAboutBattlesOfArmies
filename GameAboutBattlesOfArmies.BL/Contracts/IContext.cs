namespace GameAboutBattlesOfArmies.BL.Contracts
{
    public interface IContext
    {
        public List<IUnit> listArmie1 { get ; set ; }
        public List<IUnit> listArmie2 { get; set; }
        public List<IUnit> Armie1 { get; set; }
        public List<IUnit> Armie2 { get; set; }
        public bool chet { get; set; }
        public ITurnStrategy GetStrategy { get; }
        public ITurnStrategy ChangeStrategy(ITurnStrategy strategy);
        public void ExecuteTurn();

    }
}
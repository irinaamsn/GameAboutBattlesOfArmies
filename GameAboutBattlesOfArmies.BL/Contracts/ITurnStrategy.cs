using GameAboutBattlesOfArmies.BL.Memento;


namespace GameAboutBattlesOfArmies.BL.Contracts
{
    public interface ITurnStrategy
    {
        public List<IUnit> listArmie1 { get; set; }
        public List<IUnit> listArmie2 { get; set; }
        public bool chet { get;set; }
        public void TurnArmies();       
    }
}

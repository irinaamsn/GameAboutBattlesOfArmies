using GameAboutBattlesOfArmies.BL.Contracts;
namespace GameAboutBattlesOfArmies.BL.Memento
{
    public class TurnMemento
    {
        public List<IUnit> listArmie1 { get; set; }
        public List<IUnit> listArmie2 { get; set; }
        public ITurnStrategy turn;
        public TurnMemento(List<IUnit> listArmie1, List<IUnit> listArmie2, ITurnStrategy turn)
        {
            this.listArmie1 = listArmie1;
            this.listArmie2 = listArmie2;
            this.turn = turn;
        }
    }
}

using GameAboutBattlesOfArmies.BL.Models;


namespace GameAboutBattlesOfArmies.BL.Contracts
{
    public interface IDataSaver
    {
        public void Save(Armie item);
        //public Armie Load();
    }
}



using GameAboutBattlesOfArmies.BL.Controller;
using GameAboutBattlesOfArmies.BL.Controlller;
using GameAboutBattlesOfArmies.BL.Models;

namespace GameAboutBattlesOfArmies.BL.Contracts
{
    public interface IFightFacade
    {
        ArmieController GetArmie1 { get; }
        ArmieController GetArmie2 { get; }
        public int GetMoves { get; }
        public Fight GetFight { get; }
        void Start();
        //void GetResultFight();

        /* Skipped*/
    }
}

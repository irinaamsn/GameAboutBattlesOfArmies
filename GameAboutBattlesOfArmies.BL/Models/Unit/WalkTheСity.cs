using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Enums;

namespace GameAboutBattlesOfArmies.BL.Models.Unit
{
    public class WalkTheСity:IWalkTheCity
    {
        public int Attack { get; set; } = 0;
        public int Defence { get; set; } = 15;
        public int HitPoints { get; set; } = 4;
       
    }
}

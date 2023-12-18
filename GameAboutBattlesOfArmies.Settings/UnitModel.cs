using GameAboutBattlesOfArmies.BL.Contracts.SA;
using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Controller.Decorator.SADecorator;
using GameAboutBattlesOfArmies.BL.Models;

namespace GameAboutBattlesOfArmies.Settings
{
    public class UnitModel
    {
        public int UnitDescriptionId { get; set; }
        public string? UnitName { get; set; }
        public string? FullName { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int HitPoints { get; set; }
        public int UnitPrice { get; }
       
    }
}
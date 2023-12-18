using GameAboutBattlesOfArmies.BL.Contracts;
using System.Text.Json.Serialization;
using GameAboutBattlesOfArmies.BL.Controller.Decorator.SADecorator;

namespace GameAboutBattlesOfArmies.BL.Models
{
    public class Armie
    {
        [JsonIgnore]
        public int ArmiePrice { get; set; } 
        public string TeamName { get;  set; } = "Debbugers";
        
        public List<IUnit> UnitDescriptions { get;  set; } = new List<IUnit> { };
        public List<UnitDecoratorBase> UnitSADescriptions { get; set; } = new List<UnitDecoratorBase> { };

        public List<int> Units { get;  set; } = new List<int> { };

        [JsonIgnore]
        public List<IUnit> AllUnits { get; set; } = new List<IUnit>();


    }
}

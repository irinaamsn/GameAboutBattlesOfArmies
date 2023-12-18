using GameAboutBattlesOfArmies.BL.Contracts.SA;
using GameAboutBattlesOfArmies.BL.Enums;
using GameAboutBattlesOfArmies.BL.Models.Repository;

namespace GameAboutBattlesOfArmies.BL.Models.Unit
{
    public class HeavyInfantry : UnitRepository, ICanWearBuf
    {
       // public string Id { get; set; } = Guid.NewGuid().ToString();
        public HeavyInfantry()
        {
            UnitDescriptionId = (int)EnumUnitID.Heavy;
            UnitName = "Heavy";
            Attack = 3;
            Defence = 5;
            HitPoints = 5;
        }
        public override string ToString()
        {
            return UnitName;
        }

    }
}

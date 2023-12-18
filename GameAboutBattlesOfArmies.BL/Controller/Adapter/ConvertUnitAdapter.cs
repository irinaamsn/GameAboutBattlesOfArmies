using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Enums;
using GameAboutBattlesOfArmies.BL.Models.Repository;
using GameAboutBattlesOfArmies.BL.Models.Unit;


namespace GameAboutBattlesOfArmies.BL.Controller.Adapter
{
    public class ConvertUnitAdapter : UnitRepository
    {
        private readonly IWalkTheCity _walkTheСity;

        public ConvertUnitAdapter(IWalkTheCity walkTheСity)
        {          
            Attack = walkTheСity.Attack;
            Defence = walkTheСity.Defence;
            UnitDescriptionId = (int)EnumUnitID.WalkTheCity;
            UnitName = "WalkTheCity";
            HitPoints = walkTheСity.HitPoints;
            _walkTheСity = walkTheСity;
        }

        public override string ToString()
        {
            return UnitName;
        }

    }
}

using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Contracts.SA;
using GameAboutBattlesOfArmies.BL.Enums;
using GameAboutBattlesOfArmies.BL.Models.Repository;

namespace GameAboutBattlesOfArmies.BL.Models.Unit
{
    public class LightInfantry : UnitRepository, IHealerable, IClonable  
    {
        public int MaxHitPoints => (int)EnumMaxHP.LightInfantry;

        public LightInfantry()  
        {
            UnitDescriptionId = (int)EnumUnitID.Light;
            UnitName = "Light";
            Attack = 2;
            Defence = 2;
            HitPoints = 4;
        }
        public IClonable Clone() => (IClonable)MemberwiseClone();
       
        public override string ToString()
        {
            return UnitName;
        }

    }
}

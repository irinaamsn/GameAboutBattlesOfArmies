using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Contracts.SA;
using GameAboutBattlesOfArmies.BL.Enums;
using GameAboutBattlesOfArmies.BL.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GameAboutBattlesOfArmies.BL.Models.Unit
{
    public class Knight : UnitRepository
    {
        //public override int UnitDescriptionId { get; set; } = (int)EnumUnitID.Knight;
        //public override string? UnitName { get; set; } = "Knight";
        //public override int Attack { get; set; } = 3;
        //public override int Defence { get; set; } = 3;
        //public override int HitPoints { get; set; } = 10;
        public Knight()
        {
            UnitDescriptionId = (int)EnumUnitID.Knight;
            UnitName  = "Knight";
            Attack  = 3;
            Defence  = 3;
            HitPoints  = 10;
        }
        public override string ToString()
        {
            return UnitName;
        }

    }
}

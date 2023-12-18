using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Contracts.SA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GameAboutBattlesOfArmies.BL.Controller.Prototype
{
    public interface IClone
    {
        public IClone Clone();
        
    }
}

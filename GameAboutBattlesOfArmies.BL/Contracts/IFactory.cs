using GameAboutBattlesOfArmies.BL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAboutBattlesOfArmies.BL.Contracts
{
    public interface IFactory
    {
        IUnit CreateUnit(IUnit unit);
       
    }
}
  
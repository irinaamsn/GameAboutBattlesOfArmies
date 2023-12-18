using GameAboutBattlesOfArmies.BL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAboutBattlesOfArmies.BL.Contracts.SA
{
    public interface ICanWearBuf
    {
        public bool CanWearBuf()
        {
            var rnd = new Random();
            var num = rnd.Next(0, 100);
            if (num < 10 && num > 0)
                return false;
            return true;
        }

    }
}

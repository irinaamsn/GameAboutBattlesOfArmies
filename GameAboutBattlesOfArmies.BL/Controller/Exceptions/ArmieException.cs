using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAboutBattlesOfArmies.BL.Controlller.Exceptions
{
    public class ArmieException: Exception
    {
        public ArmieException(string message) : base(message) { }
    }
}

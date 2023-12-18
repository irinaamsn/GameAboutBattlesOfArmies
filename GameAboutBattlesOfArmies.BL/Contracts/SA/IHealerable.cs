using GameAboutBattlesOfArmies.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAboutBattlesOfArmies.BL.Contracts.SA
{
    public interface IHealerable
    {
        //Healer, LightInfactry, Archer
        public int MaxHitPoints { get; }//TODO
        public bool CanHealMe(int hp, int strength)
        {
            if (hp + strength < MaxHitPoints)
                return true;
            return false;
        }
    }
}

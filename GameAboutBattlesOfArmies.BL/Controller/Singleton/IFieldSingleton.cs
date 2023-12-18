using GameAboutBattlesOfArmies.BL.Models.Singleton;
using GameAboutBattlesOfArmies.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAboutBattlesOfArmies.BL.Controller.Singleton
{
    public interface IFieldSingleton
    {
        public Armie Armie1 { get; set; }
        public Armie Armie2 { get; set; }
        private static BattleFieldSingleton? instance;
        
    }
}

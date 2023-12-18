using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Controller.Singleton;
using GameAboutBattlesOfArmies.BL.Controlller;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAboutBattlesOfArmies.BL.Models.Singleton
{
    public class BattleFieldSingleton:IFieldSingleton
    {
        public Armie Armie1 { get; set; }
        public Armie Armie2 { get; set; }
        private static BattleFieldSingleton? instance;
        BattleFieldSingleton(Armie armie1, Armie armie2)
        {
            Armie1 = armie1;
            Armie2 = armie2;
        }

        public static BattleFieldSingleton getInstance(Armie armie1, Armie armie2)
        {
            return instance ??= new BattleFieldSingleton(armie1, armie2);
        }
    }
}

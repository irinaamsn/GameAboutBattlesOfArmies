using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Enums;
using GameAboutBattlesOfArmies.BL.Models;
using GameAboutBattlesOfArmies.BL.Models.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAboutBattlesOfArmies.BL.Bridge
{
    public class CreateLight:CreatorUnit
    {
        public CreateLight(IFactory factory) : base(factory) { }
        public override IUnit GetUnit(Armie armie)
        {
            var light = new LightInfantry();
            light.MyArmie = armie;
            return factory.CreateUnit(light);
        }
    }
}

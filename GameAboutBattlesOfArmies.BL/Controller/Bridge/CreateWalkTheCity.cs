using GameAboutBattlesOfArmies.BL.Bridge;
using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Controller.Adapter;
using GameAboutBattlesOfArmies.BL.Models;
using GameAboutBattlesOfArmies.BL.Models.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAboutBattlesOfArmies.BL.Controller.Bridge
{
    public class CreateWalkTheCity : CreatorUnit
    {
        public CreateWalkTheCity(IFactory factory) : base(factory) { }
        public override IUnit GetUnit(Armie armie)
        {
            var adapter = new ConvertUnitAdapter(new WalkTheСity());
            adapter.MyArmie = armie;
            return factory.CreateUnit(adapter);
        }
    }
}

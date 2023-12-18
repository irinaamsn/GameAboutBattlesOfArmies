using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Controller.Decorator.SADecorator;
using GameAboutBattlesOfArmies.BL.Controller.Proxy;
using GameAboutBattlesOfArmies.BL.Enums;
using GameAboutBattlesOfArmies.BL.Models.Unit;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GameAboutBattlesOfArmies.BL.Models.Factory
{
    public class UnitFactory : IFactory
    {
        public IUnit CreateUnit(IUnit unit)
        {
            var proxy = new UnitLoggingProxy(unit);
           
            return proxy;
        }

        public override string ToString()
        {
            return "Unit";
        }
    }
}

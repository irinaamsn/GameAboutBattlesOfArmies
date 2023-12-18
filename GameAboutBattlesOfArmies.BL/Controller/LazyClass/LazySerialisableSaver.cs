using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Controlller;
using GameAboutBattlesOfArmies.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GameAboutBattlesOfArmies.BL.Controller.LazyClass
{
    public class LazySerialisableSaver : IDataSaver
    {
        IDataSaver _wrapperClass = null;
        protected IDataSaver WrapperClass
        {
            get
            {
                if (_wrapperClass == null)
                    _wrapperClass = new SerialisableArmie();
                return _wrapperClass;

            }
        }
        public void Save(Armie armie) => WrapperClass.Save(armie);

    }
}

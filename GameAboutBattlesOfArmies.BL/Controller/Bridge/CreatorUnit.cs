using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Models;


namespace GameAboutBattlesOfArmies.BL.Bridge
{
    public abstract class CreatorUnit
    {
        protected IFactory factory;
       
        public CreatorUnit(IFactory factory)
        {
            this.factory = factory;
        }
        public abstract IUnit GetUnit(Armie armie);
    }
}

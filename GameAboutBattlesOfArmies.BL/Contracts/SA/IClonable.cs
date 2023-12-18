

namespace GameAboutBattlesOfArmies.BL.Contracts.SA
{
    public interface IClonable
    {
        //Light
        public IClonable Clone();
        public bool CanCloneMe(int strength)
        {
            var rnd = new Random();
            var num = rnd.Next(0,100);
            if (num < 10 && num > 0) return true;               
            return false;
        }
    }
}

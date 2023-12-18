using GameAboutBattlesOfArmies.BL.Controller;
using GameAboutBattlesOfArmies.BL.Controller.Facade;
using GameAboutBattlesOfArmies.BL.Controlller;


namespace GameAboutBattlesOfArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            var armie1 = new ArmieController(100);//my armie
            var armie2 = new ArmieController(100);
            var facade = new FightFacade(new Fight(armie1, armie2));
            facade.Start();


        }
       
    }

}

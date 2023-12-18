using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Controller.Command;
using GameAboutBattlesOfArmies.BL.Controlller;

namespace GameAboutBattlesOfArmies.BL.Controller.Facade
{
    public class FightFacade:IFightFacade
    {
        Fight fight;
        ArmieController myArmie;
        ArmieController adversaryArmie;
        TurnClient client;
        public FightFacade(Fight fight)
        {
            this.fight = fight;
            myArmie = fight.myArmie;
            adversaryArmie = fight.adversaryArmie; 
            myArmie.armie = fight.myArmie.GetArmie(fight.myArmie.ArmiePrice);
            adversaryArmie.armie = fight.adversaryArmie.GetArmie(fight.adversaryArmie.ArmiePrice);
            fight.listArmie1 = fight.listArmie1.Concat(fight.singletonField.Armie1.AllUnits).ToList();
            fight.listArmie2 = fight.listArmie2.Concat(fight.singletonField.Armie2.AllUnits).ToList();
            //fight = new Fight(armie1.armie, fight.adversaryArmie);
            //client = new TurnClient();
        }
        public ArmieController GetArmie1 => myArmie;
        public ArmieController GetArmie2 => adversaryArmie;
        public int GetMoves => fight._countMoves;
        public Fight GetFight => fight;
        public void Start()
        {
            myArmie.Save(myArmie.armie);
            ManageTurn();
            Console.WriteLine();
            fight.GetResultFight();
            Console.WriteLine();
            fight.GetHistoryResultsMoves();
        }  
        public void ManageTurn()
        {
            var _countMoves = Fight.COUNT_MOVES;
            while (_countMoves > 0)
            {
                client.StartTurn(fight.listArmie1, fight.listArmie2,_countMoves);
                fight.SummingUpResults(Fight.COUNT_MOVES - _countMoves);
                fight.UpdateArmies();
                Console.WriteLine($"\tRound {5-_countMoves} finished\t");
                _countMoves--;

            }
            Console.WriteLine("Game Over");
        }
    }
}

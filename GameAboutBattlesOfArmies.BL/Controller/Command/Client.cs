
using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Models;
using GameAboutBattlesOfArmies.BL.Strategy;

namespace GameAboutBattlesOfArmies.BL.Controller.Command
{
    public class TurnClient
    {
        Invoker invoker;
        TurnCommand turnCommand;
        StrategyCommand strategyCommand;
        ITurnStrategy turn;
        ContextTurn context;
        
        public TurnClient()
        {
            invoker = new Invoker();            
        }

        public void StartTurn(List<IUnit> listArmie1, List<IUnit> listArmie2,int _countMoves)
        {
           // turn = new TurnStrategyRows(listArmie1, listArmie2, _countMoves % 2 == 0);//по умолчанию//??
            context = new ContextTurn(turn);
            turnCommand = new TurnCommand(context);
            strategyCommand = new StrategyCommand(context);
            invoker.SetCommand(0,turnCommand);
            invoker.SetCommand(1, strategyCommand);
            while (context.listArmie1.Count > 0 && context.listArmie2.Count > 0 )
            {                
                Console.WriteLine("Начать ход - 0, Отменить действие - 1, Повторить действие - 2, Изменить стратегию - 3, Дойти до конца - 4 ");
                var num = Console.ReadLine();
                switch (num)
                {
                    case "0":
                        invoker.Run(0);
                        break;
                    case "1":
                        invoker.Cancel();
                        break;
                    case "2":
                        invoker.Repeat();
                        break;
                    case "3":
                        invoker.Run(1);
                        break;
                    case "4":
                        ReachTheEnd();
                        break;                    
                }
            }
        }
        void ReachTheEnd()
        {
            var IsStop = false;
            
            var countArmie1 = context.listArmie1.Count; var countArmie2 = context.listArmie2.Count; var timer = 0; 
           // var copyArmie1= new List<IUnit>();var copyArmie2= new List<IUnit>();
           // context.listArmie1.ForEach(x => copyArmie1.Add((IUnit)x.Clone())); context.listArmie2.ForEach(x => copyArmie2.Add((IUnit)x.Clone()));

            while (context.listArmie1.Count > 0 && context.listArmie2.Count > 0 && !IsStop && timer<=15)
            {
                invoker.Run(0);

                if (countArmie1 != context.listArmie1.Count || countArmie2 != context.listArmie2.Count)
                {
                    countArmie1 = context.listArmie1.Count; countArmie2 = context.listArmie2.Count;
                   // copyArmie1.Clear(); copyArmie2.Clear();
                   // context.listArmie1.ForEach(x => copyArmie1.Add((IUnit)x.Clone())); context.listArmie2.ForEach(x => copyArmie2.Add((IUnit)x.Clone()));
                }
                //else if (copyArmie1.All(x => x.UnitName == context.listArmie1[copyArmie1.FindIndex(y => y == x)].UnitName) && copyArmie2.All(x => x.UnitName == context.listArmie2[copyArmie2.FindIndex(y => y == x)].UnitName))
                //{    
                //    if (copyArmie1.Any(x => x.HitPoints != context.listArmie1[copyArmie1.FindIndex(y=>y==x)].HitPoints) || copyArmie2.Any((x) => x.HitPoints != context.listArmie2[copyArmie2.FindIndex(y => y == x)].HitPoints))
                //    {
                //        countArmie1 = context.listArmie1.Count; countArmie2 = context.listArmie2.Count;
                //        copyArmie1.Clear(); copyArmie2.Clear();
                //        context.listArmie1.ForEach(x => copyArmie1.Add((IUnit)x.Clone())); context.listArmie2.ForEach(x => copyArmie2.Add((IUnit)x.Clone()));
                //    }
                //}
                //else if (!copyArmie1.All(x => x.UnitName == context.listArmie1[copyArmie1.FindIndex(y => y == x)].UnitName) || !copyArmie2.All(x => x.UnitName == context.listArmie2[copyArmie2.FindIndex(y => y == x)].UnitName))
                //{
                //    countArmie1 = context.listArmie1.Count; countArmie2 = context.listArmie2.Count;
                //    copyArmie1.Clear(); copyArmie2.Clear();
                //    context.listArmie1.ForEach(x => copyArmie1.Add((IUnit)x.Clone())); context.listArmie2.ForEach(x => copyArmie2.Add((IUnit)x.Clone()));
                //}
                else timer++;
                if (timer > 15) IsStop = true;
            }
           
            if (IsStop )
            {
                Console.WriteLine("С текущей стратегией нельзя дойти до победного, смените стратегию!");
                invoker.Run(1);
            }
        }
    }
}

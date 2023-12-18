using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Memento;
using GameAboutBattlesOfArmies.BL.Models;
using GameAboutBattlesOfArmies.BL.Strategy;

namespace GameAboutBattlesOfArmies.BL.Controller
{
    public class ContextTurn
    {
        private ITurnStrategy contextStrategy;
        public List<IUnit> listArmie1 { get => contextStrategy.listArmie1; set => contextStrategy.listArmie1 = value; }
        public List<IUnit> listArmie2 { get => contextStrategy.listArmie2; set => contextStrategy.listArmie2 = value; }
        //public List<IUnit> Armie1 { get; set; }
        //public List<IUnit> Armie2 { get; set; }
        public bool chet { get =>contextStrategy.chet ; set=> contextStrategy.chet=value; } 
        public ContextTurn(ITurnStrategy strategy)
        {
            contextStrategy = strategy;
        }
        public ITurnStrategy GetStrategy=>contextStrategy;
        public void PrintArmie()
        {
            Console.WriteLine($"Текущая стратегия {contextStrategy}"); Console.WriteLine();
            foreach (var item in listArmie1)
            {
                Console.WriteLine($" | Name - {item.UnitName} | HP - {item.HitPoints} | Attack - {item.Attack} | Defence - {item.Defence} | "); Console.WriteLine();
            }
            Console.WriteLine();
            foreach (var item in listArmie2)
            {
                Console.WriteLine($" | Name - {item.UnitName} | HP - {item.HitPoints} | Attack - {item.Attack} | Defence - {item.Defence} |"); Console.WriteLine();
            }
            Console.WriteLine();
        }
        public ITurnStrategy ChangeStrategy(ITurnStrategy strategy)
        {
            contextStrategy = strategy;
            return strategy;
        }
        //public ITurnStrategy ChooseStrategy()
        //{
        //    ITurnStrategy strategy = null;
        //    Console.WriteLine("Horisontally - 1, Rows - 2, Vertically - 3,  "); var num2 = Console.ReadLine();
        //    //if (num2 == "1") strategy = new TurnStrategyHorizontally(contextStrategy.listArmie1, contextStrategy.listArmie2, contextStrategy.chet);
        //    //else if (num2 == "2") strategy = new TurnStrategyRows(contextStrategy.listArmie1, contextStrategy.listArmie2, contextStrategy.chet);
        //    //else if (num2 == "3") strategy = new TurnStrategyVertically(contextStrategy.listArmie1, contextStrategy.listArmie2, contextStrategy.chet);
        //    //else
        //    //{
        //    //    Console.WriteLine("Неверный ввод");
        //    //    return contextStrategy;
        //    //} 
        //    contextStrategy = strategy;
        //    Console.WriteLine($"Стратегия изменена на {strategy}");
        //    return strategy;
        //}
        public void ExecuteTurn()
        {
            contextStrategy.TurnArmies();
            listArmie1.RemoveAll(x => x.Death());
            listArmie2.RemoveAll(x => x.Death());
        }
     
    }
}

using GameAboutBattlesOfArmies.BL.Contracts;
using System.Reflection;

namespace GameAboutBattlesOfArmies.BL.Controller.Command
{
    public class StrategyCommand:ICommand
    {
        private ContextTurn contextStrategy;
       // TurnHistory turnHistory;
        Stack<ITurnStrategy> contextUndo;
        Stack<ITurnStrategy> contextRedo;
        public StrategyCommand(ContextTurn context)
        {
            contextStrategy = context;
            contextUndo = new Stack<ITurnStrategy>();
            contextRedo = new Stack<ITurnStrategy>();
           // turnHistory = TurnHistory.getInstance();
        }

        public void Execute()
        {
            var fieldStrategy = GetCurrentStrategy();
            contextUndo.Push(fieldStrategy);
            contextRedo.Clear();
        }
        ITurnStrategy GetCurrentStrategy()
        {
            FieldInfo field = typeof(ContextTurn).GetField("contextStrategy", BindingFlags.Instance | BindingFlags.NonPublic);
            return (ITurnStrategy)field.GetValue(contextStrategy);
        }
        public void Undo()
        {
            FieldInfo field = typeof(ContextTurn).GetField("contextStrategy", BindingFlags.Instance | BindingFlags.NonPublic);//TODO
            var fieldStrategy = GetCurrentStrategy();
            contextRedo.Push(fieldStrategy);
            var strategy = contextUndo.Peek();
            strategy.listArmie1 = contextStrategy.listArmie1;
            strategy.listArmie2 = contextStrategy.listArmie2;
            strategy.chet = contextStrategy.chet;
            contextStrategy.ChangeStrategy(strategy);
            contextUndo.Pop();
            contextStrategy.PrintArmie();

        }

        public void Redo()
        {
            var strategy = contextRedo.Peek();
            strategy.listArmie1 = contextStrategy.listArmie1;
            strategy.listArmie2 = contextStrategy.listArmie2;
            strategy.chet = contextStrategy.chet;
            var fieldStrategy = GetCurrentStrategy();
            contextUndo.Push(fieldStrategy);
            contextStrategy.ChangeStrategy(strategy);
            contextRedo.Pop();
            contextStrategy.PrintArmie();
            //turnHistory.UndoStrategy.Push(turn.GetState());
            //turn.RestoreStrategy(turnHistory.RedoStrategy.Pop());
        }
    }
}

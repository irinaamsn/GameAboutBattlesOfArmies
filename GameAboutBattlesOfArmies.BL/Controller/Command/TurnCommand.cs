using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Memento;
using GameAboutBattlesOfArmies.BL.Models;


namespace GameAboutBattlesOfArmies.BL.Controller.Command
{
    public class TurnCommand : ICommand
    {
        private ContextTurn turn;
        public List<IUnit> Armie1 { get; set; }
        public List<IUnit> Armie2 { get; set; }
        //TurnHistory turnHistory;
        Stack<(List<IUnit>, List<IUnit>)> unitsUndo;
        Stack<(List<IUnit>, List<IUnit>)> unitsRedo;
      
        public TurnCommand(ContextTurn turn)
        {
            this.turn = turn;
            unitsUndo = new Stack<(List<IUnit>, List<IUnit>)>();
            unitsRedo = new Stack<(List<IUnit>, List<IUnit>)>();
            //turnHistory = TurnHistory.getInstance();
        }
        public ContextTurn ChangeTurn(ContextTurn _turn)
        {
            turn = _turn;
           // turn.listArmie1 = _turn.listArmie1;
            //turn.listArmie2 = _turn.listArmie2;
            return _turn;
        }
    
        public void Execute()
        {
            Armie1 = new List<IUnit>(); Armie2 = new List<IUnit>();
            turn.listArmie1.ForEach(x => Armie1.Add((IUnit)x.Clone()));
            turn.listArmie2.ForEach(x => Armie2.Add((IUnit)x.Clone()));

            unitsUndo.Push((Armie1, Armie2));
            unitsRedo.Clear();

            //turnHistory.Undo.Push(turn.SaveState());
            //turnHistory.Redo.Clear();
            turn.ExecuteTurn();
            turn.PrintArmie();
        }

        public void Undo()
        {
            unitsRedo.Push((turn.listArmie1, turn.listArmie2));
            var armies = unitsUndo.Peek();
            turn.listArmie1 = armies.Item1;
            turn.listArmie2 = armies.Item2;
            unitsUndo.Pop();
            turn.PrintArmie();
        }

        public void Redo()
        {
            //turnHistory.Undo.Push(turn.GetState());
            //turn.RestoreState(turnHistory.Redo.Pop());

            unitsUndo.Push((turn.listArmie1, turn.listArmie2));
            var armies = unitsRedo.Peek();
            turn.listArmie1 = armies.Item1;
            turn.listArmie2 = armies.Item2;
            unitsRedo.Pop();
            turn.PrintArmie();
        }
    }
}

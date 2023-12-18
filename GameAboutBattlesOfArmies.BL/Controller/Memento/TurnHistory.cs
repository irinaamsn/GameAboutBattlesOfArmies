using GameAboutBattlesOfArmies.BL.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAboutBattlesOfArmies.BL.Memento
{
    public class TurnHistory
    {
        public Stack<TurnMemento> Undo { get; private set; }
        public Stack<TurnMemento> Redo { get; private set; }
        public Stack<TurnMemento> UndoStrategy { get; private set; }
        public Stack<TurnMemento> RedoStrategy { get; private set; }
        private static TurnHistory? instance;
        TurnHistory() 
        {
            Undo = new Stack<TurnMemento>();
            Redo = new Stack<TurnMemento>();
            UndoStrategy = new Stack<TurnMemento>();
            RedoStrategy = new Stack<TurnMemento>();
        }
        public static TurnHistory getInstance()
        {
            return instance ??= new TurnHistory();
        }
        //public TurnHistory()
        //{
        //    Undo = new Stack<TurnMemento>(); 
        //    Redo = new Stack<TurnMemento>();
        //    UndoStrategy = new Stack<TurnMemento>();
        //    RedoStrategy = new Stack<TurnMemento>();
        //}
    }
}

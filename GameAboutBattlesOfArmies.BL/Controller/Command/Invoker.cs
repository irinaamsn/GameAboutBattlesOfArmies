
namespace GameAboutBattlesOfArmies.BL.Controller.Command
{
    public class Invoker
    {
        private List<ICommand> commands;
        public readonly Stack<ICommand> _undoStack = new Stack<ICommand>();
        public readonly Stack<ICommand> _redoStack = new Stack<ICommand>();
        public Invoker()
        {
            commands = new List<ICommand>() { null,null};  
        }
        public void SetCommand(int button, ICommand c) => commands[button] = c;

        public void Run(int button)
        {
            //_undoStack.Push(command);
            commands[button].Execute();
           // history.Push(command);//
                                 
            _undoStack.Push(commands[button]);
            _redoStack.Clear();
        }
        public void Cancel()
        {
            if (_undoStack.Count > 0)
            {
                ICommand command =_undoStack.Pop();
                command.Undo();
                //commands[2].Undo();
                _redoStack.Push(command);
            }           
        }
        public void Repeat()
        {
            if (_redoStack.Count > 0)
            {
                ICommand command = _redoStack.Pop();
                command.Redo();
                _undoStack.Push(command);
            }
        }
    }
}

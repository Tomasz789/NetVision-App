using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NetVision.MVRelayCmds
{
    public class RelayCommand : ICommand
    {
        Action<object> _executeMethod;
        Func<object, bool> _canExecute;

        public RelayCommand()
        {

        }
        public RelayCommand(Action<object> executeMethod, Func<object,bool> canExecute)
        {
            _executeMethod = executeMethod;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_executeMethod != null)
                return true;
            else return false;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
        public void Execute(object parameter)
        {
            _executeMethod(parameter);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AsistenteMatricula.Administrator.Library
{
    public class Command : ICommand
    {
        public Command() { }

        public static ICommand GetICommand(Action<object> MyAction)
        {
            return new Command()
            {
                CanExecuteDelegate = x => true,
                ExecuteDelegate = x =>
                {
                    if (MyAction != null)
                    {
                        if (x != null)
                        {
                            MyAction.Invoke(x);
                        }
                        else
                        {
                            MyAction.Invoke(null);
                        }
                    }
                }
            };
        }

        public Predicate<object> CanExecuteDelegate { get; set; }
        public Action<object> ExecuteDelegate { get; set; }

        public bool CanExecute(object parameter)
        {
            if (CanExecuteDelegate != null)
                return CanExecuteDelegate(parameter);
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            if (ExecuteDelegate != null)
                ExecuteDelegate(parameter);
        }
    }
}

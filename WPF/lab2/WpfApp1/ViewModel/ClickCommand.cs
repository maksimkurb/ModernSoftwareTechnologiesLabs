using System;
using System.Windows.Input;

namespace WpfApp1.ViewModel
{
    class ClickCommand : ICommand
    {
        public Predicate<object> CanExecuteDelegate { get; set; }
        public Action<object> ExecuteDelegate { get; set; }
        public ClickCommand(Action<object> action)
        {
            ExecuteDelegate = action;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteDelegate == null || CanExecuteDelegate(parameter);
        }

        public void Execute(object parameter)
        {
            if(ExecuteDelegate != null)
            {
                ExecuteDelegate(parameter);
            }
        }
    }
}

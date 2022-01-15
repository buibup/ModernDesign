using System;
using System.Windows.Input;

namespace ModernDesign.Core
{
    public class RelayCommand : ICommand
    {
        private Action<object?> _excecute;
        private Func<object?, bool>? _canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value;}
        }

        public RelayCommand(Action<object?> excecute, Func<object?, bool>? canExcecute = null)
        {
            _excecute = excecute;
            _canExecute = canExcecute;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _excecute(parameter);
        }
    }
}

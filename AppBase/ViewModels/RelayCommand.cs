using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppBase.ViewModels
{
    internal class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> _executeMethod;
        private Predicate<object> _canExecuteMethod;

        public RelayCommand(Action<object> executeMethod, Predicate<object> canExecuteMethod)
        {
            this._executeMethod = executeMethod;
            this._canExecuteMethod = canExecuteMethod;
        }

        public RelayCommand(Action<object> executeMethod) : this(executeMethod, null)
        {        }

        public bool CanExecute(object parameter)
        {
            return (_canExecuteMethod == null) ? true : _canExecuteMethod(parameter);
        }

        public void Execute(object parameter)
        {
            _executeMethod.Invoke(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}

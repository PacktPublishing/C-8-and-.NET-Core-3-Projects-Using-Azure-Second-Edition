using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Boris_Client.Helpers
{
    // https://stackoverflow.com/questions/22285866/why-relaycommand/22286816#22286816
    // https://onewindowsdev.com/2016/06/16/the-command-pattern-and-mvvm/
    // https://blogs.msdn.microsoft.com/jebarson/2017/07/26/writing-an-asynchronous-relaycommand-implementing-icommand/
    public class RelayCommandAsync<T> : ICommand
    {
        #region Fields

        readonly Func<T, Task> _execute = null;
        readonly Func<T, bool> _canExecute = null;

        #endregion

        #region Constructors

        public RelayCommandAsync(Func<T, Task> execute)
            : this(execute, null)
        {
        }

        public RelayCommandAsync(Func<T, Task> execute, Func<T, bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute.Invoke((T)parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Execute(object parameter)
        {
            _execute.Invoke((T)parameter);
        }

        #endregion
    }
}

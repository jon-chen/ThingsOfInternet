using System;
using System.Windows.Input;

namespace ThingsOfInternet.Commands
{
    public abstract class CommandBase : ICommand
    {
        #region ICommand implementation

        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);

        #endregion

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}


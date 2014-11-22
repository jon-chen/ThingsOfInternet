using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ThingsOfInternet.Commands
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter);
    }
}


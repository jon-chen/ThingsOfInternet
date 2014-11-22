using System;
using System.Threading.Tasks;

namespace ThingsOfInternet.Commands
{
    public abstract class AsyncCommandBase : CommandBase, IAsyncCommand
    {
        public abstract Task ExecuteAsync(object parameter);

        public override async void Execute(object parameter)
        {
            await ExecuteAsync(parameter);
        }
    }
}


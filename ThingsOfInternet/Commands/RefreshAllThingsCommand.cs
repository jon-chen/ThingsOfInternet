using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Practices.ServiceLocation;
using ThingsOfInternet.ViewModels;
using Unity = Microsoft.Practices.Unity;

namespace ThingsOfInternet.Commands
{
    public class RefreshAllThingsCommand : AsyncCommandBase
    {
        public override bool CanExecute(object parameter)
        {
            return parameter is IEnumerable<ThingViewModel>;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (CanExecute(parameter))
            {
                var viewModels = (IEnumerable<ThingViewModel>)parameter;
                var cmd = (IAsyncCommand)ServiceLocator.Current.GetInstance<RefreshOneThingCommand>();

                await Task.WhenAll(viewModels
                    .Where(x => cmd.CanExecute(x))
                    .Select(x => cmd.ExecuteAsync(x)));
            }
        }
    }
}
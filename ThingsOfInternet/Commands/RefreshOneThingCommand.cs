using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Practices.ServiceLocation;
using ThingsOfInternet.Models;
using ThingsOfInternet.Services;
using ThingsOfInternet.ViewModels;
using ThingsOfInternet.Utilities;

namespace ThingsOfInternet.Commands
{
    public class RefreshOneThingCommand : AsyncCommandBase
    {
        public override bool CanExecute(object parameter)
        {
            return parameter != null && parameter is ThingViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (CanExecute(parameter))
            {
                var viewModel = (ThingViewModel)parameter;
                var namedInstance = viewModel.Model.GetType().Name;
                try
                {
                    viewModel.Status = SyncStatus.Syncing;
                    var thingService = ServiceLocator.Current.GetInstance<IThingService>(namedInstance);
                    await thingService.QueryAsync(viewModel);
                }
                catch (ActivationException)
                {
                    // TODO: logging
                    System.Diagnostics.Debug.WriteLine("ThingService of type {0} is not registered", namedInstance);
                    viewModel.Status = SyncStatus.Error;
                    viewModel.StatusMessage = string.Format("ThingService of type {0} is not registered", namedInstance);
                }
                catch (AggregateException e)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("Failed to refresh thing - {0}", e.Flatten()));
                    viewModel.Status = SyncStatus.Error;
                    viewModel.StatusMessage = e.AsFlattenedMessage();
                }
            }
        }
    }
}


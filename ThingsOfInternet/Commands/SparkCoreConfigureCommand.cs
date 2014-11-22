using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using ThingsOfInternet.Logging;
using ThingsOfInternet.Models;
using ThingsOfInternet.Services;
using ThingsOfInternet.ViewModels;
using ThingsOfInternet.Utilities;
using Unity = Microsoft.Practices.Unity;

namespace ThingsOfInternet.Commands
{
    public abstract class SparkCoreConfigureCommand : AsyncCommandBase
    {
        [Unity.Dependency]
        protected IDialogService DialogService { get; set; }

        [Unity.Dependency]
        protected ILogger Logger { get; set; }

        protected ThingViewModel viewModel;

        protected abstract bool IsBusy { get; set; }
        protected abstract string[] PropertiesToSerialize { get; }
        protected abstract SwitchConfig SwitchConfig { get; }
        protected abstract void RevertValue();

        public override bool CanExecute(object parameter)
        {
            viewModel = parameter as ThingViewModel;
            return parameter != null && parameter is ThingViewModel && !IsBusy;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            viewModel = parameter as ThingViewModel;
            if (CanExecute(parameter))
            {
                var namedInstance = viewModel.Model.GetType().Name;

                IsBusy = true;
                RaiseCanExecuteChanged();

                try
                {
                    var thingService = ServiceLocator.Current.GetInstance<IThingService>(namedInstance);

                    if (SwitchConfig == null)
                    {
                        await thingService.ConfigureAsync(viewModel, PropertiesToSerialize);
                    }
                    else
                    {
                        await thingService.ConfigureAsync(viewModel, SwitchConfig, PropertiesToSerialize);
                    }
                }
                catch (ActivationException e)
                {
                    Logger.ErrorFormat(e, "ThingService of type {0} is not registered", namedInstance);
                }
                catch (AggregateException e)
                {
                    RevertValue();
                    await DialogService.ShowError(e.AsFriendlyMessage(), Constants.App.Title, "OK", null);
                }

                IsBusy = false;
                RaiseCanExecuteChanged();
            }
        }
    }
}


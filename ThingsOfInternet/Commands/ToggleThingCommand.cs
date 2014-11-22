using System;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using ThingsOfInternet.Models;
using ThingsOfInternet.Services;
using ThingsOfInternet.ViewModels;
using Unity = Microsoft.Practices.Unity;

namespace ThingsOfInternet.Commands
{
    public class ToggleThingCommand : SparkCoreConfigureCommand
    {
        protected override bool IsBusy
        {
            get { return viewModel.IsToggledBusy; }
            set { viewModel.IsToggledBusy = value; }
        }

        protected override string[] PropertiesToSerialize
        {
            get { return new [] { SwitchConfigProperties.IsToggled }; }
        }

        protected override SwitchConfig SwitchConfig
        {
            get { return null; }
        }

        protected override void RevertValue()
        {
            viewModel.IsToggled = !viewModel.IsToggled;
        }
    }

//    public class ToggleThingCommand : AsyncCommandBase
//    {
//        [Unity.Dependency]
//        protected IDialogService DialogService { get; set; }
//
//        public override bool CanExecute(object parameter)
//        {
//            return parameter != null && parameter is ThingViewModel && !((ThingViewModel)parameter).IsToggledBusy;
//        }
//
//        public async override Task ExecuteAsync(object parameter)
//        {
//            if (CanExecute(parameter))
//            {
//                var viewModel = (ThingViewModel)parameter;
//                var namedInstance = viewModel.Model.GetType().Name;
//
//                viewModel.IsToggledBusy = true;
//                RaiseCanExecuteChanged();
//
//                try
//                {
//                    var thingService = ServiceLocator.Current.GetInstance<IThingService>(namedInstance);
//                    await thingService.ConfigureAsync(viewModel, new [] { "OutletSwitchState" });
//                }
//                catch (ActivationException)
//                {
//                    // TODO: logging
//                    System.Diagnostics.Debug.WriteLine("ThingService of type {0} is not registered", namedInstance);
//                }
//                catch (AggregateException e)
//                {
//                    viewModel.IsToggled = !viewModel.IsToggled;
//                    await DialogService.ShowError(e.AsFriendlyMessage(), Constants.App.Title, "OK", null);
//                }
//
//                viewModel.IsToggledBusy = false;
//                RaiseCanExecuteChanged();
//            }
//        }
//    }
}


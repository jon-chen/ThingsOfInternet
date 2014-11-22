using System;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using ThingsOfInternet.Services;
using ThingsOfInternet.ViewModels;
using Unity = Microsoft.Practices.Unity;
using ThingsOfInternet.Models;

namespace ThingsOfInternet.Commands
{
    public class EnableSchedulerCommand : SparkCoreConfigureCommand
    {
        protected override bool IsBusy
        {
            get { return viewModel.IsSchedulerEnabledBusy; }
            set { viewModel.IsSchedulerEnabledBusy = value; }
        }

        protected override SwitchConfig SwitchConfig
        {
            get { return null; }
        }

        protected override string[] PropertiesToSerialize
        {
            get { return new [] { SwitchConfigProperties.IsSchedulerEnabled }; }
        }

        protected override void RevertValue()
        {
            viewModel.IsSchedulerEnabled = !viewModel.IsSchedulerEnabled;
        }
    }
//    public class EnableSchedulerCommand : AsyncCommandBase
//    {
//        [Unity.Dependency]
//        protected IDialogService DialogService { get; set; }
//
//        public override bool CanExecute(object parameter)
//        {
//            return parameter != null && parameter is ThingViewModel && !((ThingViewModel)parameter).IsSchedulerEnabledBusy;
//        }
//
//        public async override Task ExecuteAsync(object parameter)
//        {
//            if (CanExecute(parameter))
//            {
//                var viewModel = (ThingViewModel)parameter;
//                var namedInstance = viewModel.Model.GetType().Name;
//
//                viewModel.IsSchedulerEnabledBusy = true;
//                RaiseCanExecuteChanged();
//
//                try
//                {
//                    var thingService = ServiceLocator.Current.GetInstance<IThingService>(namedInstance);
//                    await thingService.ConfigureAsync(viewModel, new [] { "SchedulerEnabled" });
//                }
//                catch (ActivationException)
//                {
//                    // TODO: logging
//                    System.Diagnostics.Debug.WriteLine("ThingService of type {0} is not registered", namedInstance);
//                }
//                catch (AggregateException e)
//                {
//                    viewModel.IsSchedulerEnabled = !viewModel.IsSchedulerEnabled;
//                    await DialogService.ShowError(e.AsFriendlyMessage(), Constants.App.Title, "OK", null);
//                }
//
//                viewModel.IsSchedulerEnabledBusy = false;
//                RaiseCanExecuteChanged();
//            }
//        }
//    }
}
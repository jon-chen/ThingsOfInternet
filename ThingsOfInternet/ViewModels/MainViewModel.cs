using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Xamarin.Forms;
using ThingsOfInternet.Commands;
using ThingsOfInternet.Messaging;
using ThingsOfInternet.Models;
using ThingsOfInternet.Services;
using Unity = Microsoft.Practices.Unity;

namespace ThingsOfInternet.ViewModels
{
	public class MainViewModel : PageViewModelBase
    {
        [Unity.Dependency]
        protected ViewModelLocatorService ViewModelLocatorService { get; set; }

        [Unity.Dependency]
        protected SparkCoreService SparkCoreService { get; set; }

        [Unity.Dependency]
        protected SparkSubscriberService SparkSubscriberService { get; set; }

        [Unity.Dependency]
        protected INavigationService NavigationService { get; set; }

        protected bool isRefreshing;
        protected ICommand refreshCommand;
        protected ICommand showDetailsCommand;

        public MainViewModel(ViewModelLocatorService vmLocatorService)
        {
            ViewModelLocatorService = vmLocatorService;

            TogglableItems = new ObservableCollection<Grouping<string, ThingViewModel>>();
            NavigationTitle = Constants.App.Title;

            var things = ViewModelLocatorService.GetThings();
            var groupedThings = things
                .GroupBy(x => x.Category)
                .Select(x => new Grouping<string, ThingViewModel>(x.Key, x));

            foreach (var item in groupedThings)
            {
                TogglableItems.Add(item);
            }

            MessengerInstance.Register<SparkCoreStatusMessage>(this, OnSparkCoreStatusMessage);
            MessengerInstance.Register<SparkEventToggleMessage>(this, OnSparkEventToggleMessage);
            MessengerInstance.Register<GeofenceEnteredMessage>(this, OnGeofenceEnteredMessage);
            MessengerInstance.Register<GeofenceLeftMessage>(this, OnGeofenceLeftMessage);
        }

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { Set(() => IsRefreshing, ref isRefreshing, value); }
        }

        public ObservableCollection<Grouping<string, ThingViewModel>> TogglableItems 
        {
            get;
            private set;
        }

        public ICommand RefreshCommand
        {
            get 
            { 
                return refreshCommand ?? (refreshCommand = new RelayCommand(async () =>
                    {
                        IsRefreshing = true;
                        IAsyncCommand refresh = ServiceLocator.Current.GetInstance<RefreshAllThingsCommand>();
                        await refresh.ExecuteAsync(TogglableItems.SelectMany(x => x));
                        IsRefreshing = false;
                    })); 
            }
        }

        public ICommand ShowDetailsCommand
        {
            get { return showDetailsCommand ?? (showDetailsCommand = ServiceLocator.Current.GetInstance<ShowDetailsCommand>()); }
        }

        public override void Initialize()
        {
            base.Initialize();

            ICommand refresh = ServiceLocator.Current.GetInstance<RefreshAllThingsCommand>();
            refresh.Execute(TogglableItems.SelectMany(x => x));
        }

        protected void OnSparkCoreStatusMessage(SparkCoreStatusMessage message)
        {
            var viewModel = ViewModelLocatorService.GetThings()
                .First(x => x.DeviceId == message.DeviceId);

            viewModel.MessageBusStatus = message.Status;
        }

        protected void OnSparkEventToggleMessage(SparkEventToggleMessage message)
        {
            var viewModel = ViewModelLocatorService.GetThings()
                .First(x => x.DeviceId == message.DeviceId);

            viewModel.IsToggled = message.ToggleState;
        }

        protected void OnGeofenceEnteredMessage(GeofenceEnteredMessage message)
        {
            ICommand cmd = ServiceLocator.Current.GetInstance<SetHomeStatusCommand>();
            foreach (var viewModel in ViewModelLocatorService.GetThings())
            {
                cmd.Execute(viewModel);
            }
        }

        protected void OnGeofenceLeftMessage(GeofenceLeftMessage message)
        {
            ICommand cmd = ServiceLocator.Current.GetInstance<SetAwayStatusCommand>();
            foreach (var viewModel in ViewModelLocatorService.GetThings())
            {
                cmd.Execute(viewModel);
            }
        }
	}
}
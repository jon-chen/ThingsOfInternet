using System;
using ThingsOfInternet.Models;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using Microsoft.Practices.ServiceLocation;
using ThingsOfInternet.Commands;

namespace ThingsOfInternet.ViewModels
{
    public class ThingViewModel : PageViewModelBase
    {
        protected bool isToggledBusy;
        protected bool isSchedulerEnabledBusy;
        protected bool isHomeOnlyModeEnabledBusy;
        protected bool isResetHomeStatusBusy;
        protected ICommand toggleCommand;
        protected ICommand enableSchedulerCommand;
        protected ICommand toggleHomeOnlyModeCommand;
        protected ICommand resetCurrentHomeCounterCommand;

        public ThingViewModel(IThing model)
        {
            this.Model = model;
            NavigationTitle = Category;
        }

        public IThing Model 
        { 
            get; 
            private set; 
        }

        public string Category 
        { 
            get { return Model.Category; } 
        }

        public string DisplayName 
        { 
            get { return Model.DisplayName; } 
            set
            {
                var t = Model.DisplayName;
                if (Set(() => DisplayName, ref t, value))
                {
                    Model.DisplayName = t;
                }
            }
        }

        public bool IsSchedulerEnabled
        {
            get { return Model.IsSchedulerEnabled; }
            set
            {
                var t = Model.IsSchedulerEnabled;
                if (Set(() => IsSchedulerEnabled, ref t, value))
                {
                    Model.IsSchedulerEnabled = t;
                }
            }
        }

        public bool IsSchedulerEnabledBusy
        {
            get { return isSchedulerEnabledBusy; }
            set { Set(() => IsSchedulerEnabledBusy, ref isSchedulerEnabledBusy, value); }
        }

        public bool IsToggled 
        { 
            get { return Model.IsToggled; } 
            set 
            { 
                var t = Model.IsToggled;
                if (Set(() => IsToggled, ref t, value))
                {
                    Model.IsToggled = t;
                }
            }
        }

        public bool IsToggledBusy
        {
            get { return isToggledBusy; }
            set { Set(() => IsToggledBusy, ref isToggledBusy, value); }
        }

        public bool IsHomeOnlyModeEnabled
        {
            get { return Model.IsHomeOnlyModeEnabled; }
            set 
            { 
                var t = Model.IsHomeOnlyModeEnabled;
                if (Set(() => IsHomeOnlyModeEnabled, ref t, value))
                {
                    Model.IsHomeOnlyModeEnabled = t;
                }
            }
        }

        public bool IsHomeOnlyModeEnabledBusy
        {
            get { return isHomeOnlyModeEnabledBusy; }
            set { Set(() => IsHomeOnlyModeEnabledBusy, ref isHomeOnlyModeEnabledBusy, value); }
        }

        public bool IsResetHomeStatusBusy
        {
            get { return isResetHomeStatusBusy; }
            set { Set(() => IsResetHomeStatusBusy, ref isResetHomeStatusBusy, value); }
        }

        public string DeviceId
        {
            get { return Model.DeviceId; }
            set
            {
                var t = Model.DeviceId;
                if (Set(() => DeviceId, ref t, value))
                {
                    Model.DeviceId = t;
                }
            }
        }

        public int CurrentHomeCount
        {
            get { return Model.CurrentHomeCount; }
            set
            {
                var t = Model.CurrentHomeCount;
                if (Set(() => CurrentHomeCount, ref t, value))
                {
                    Model.CurrentHomeCount = t;
                }
            }
        }

        public SyncStatus Status
        {
            get { return Model.Status; }
            set
            {
                var t = Model.Status; 
                if (Set(() => Status, ref t, value))
                {
                    Model.Status = t;
                }
            }
        }

        public SyncStatus MessageBusStatus
        {
            get { return Model.MessageBusStatus; }
            set
            {
                var t = Model.MessageBusStatus;
                if (Set(() => MessageBusStatus, ref t, value))
                {
                    Model.MessageBusStatus = t;
                }
            }
        }

        public string StatusMessage
        {
            get { return Model.StatusMessage; }
            set
            {
                var t = Model.StatusMessage;
                if (Set(() => StatusMessage, ref t, value))
                {
                    Model.StatusMessage = t;
                }
            }
        }

        public DateTime LastUpdated
        {
            get { return Model.LastUpdated; }
            set
            {
                var t = Model.LastUpdated;
                if (Set(() => LastUpdated, ref t, value))
                {
                    Model.LastUpdated = t;
                }
            }
        }

        public ICommand ToggleThingCommand
        {
            get { return toggleCommand ?? (toggleCommand = ServiceLocator.Current.GetInstance<ToggleThingCommand>()); }
        }

        public ICommand EnableSchedulerCommand
        {
            get { return enableSchedulerCommand ?? (enableSchedulerCommand = ServiceLocator.Current.GetInstance<EnableSchedulerCommand>()); }
        }

        public ICommand ToggleHomeOnlyModeCommand
        {
            get { return toggleHomeOnlyModeCommand ?? (toggleHomeOnlyModeCommand = ServiceLocator.Current.GetInstance<ToggleHomeOnlyModeCommand>()); }
        }

        public ICommand ResetCurrentHomeCounterCommand
        {
            get { return resetCurrentHomeCounterCommand ?? (resetCurrentHomeCounterCommand = ServiceLocator.Current.GetInstance<ResetHomeStatusCommand>()); }
        }
    }
}


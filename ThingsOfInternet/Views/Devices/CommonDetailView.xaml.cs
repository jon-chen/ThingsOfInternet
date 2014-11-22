using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using ThingsOfInternet.ViewModels;

namespace ThingsOfInternet.Views
{
    public partial class CommonDetailView : ContentView
    {
        protected ThingViewModel ViewModel
        {
            get { return BindingContext as ThingViewModel; }
        }

        public CommonDetailView()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            ToggledSwitch.Toggled -= ToggledSwitch_Toggled;
            SchedulerEnabledSwitch.Toggled -= SchedulerEnabledSwitch_Toggled;
            HomeOnlyModeSwitch.Toggled -= HomeOnlyModeSwitch_Toggled;

            ToggledSwitch.Toggled += ToggledSwitch_Toggled;
            SchedulerEnabledSwitch.Toggled += SchedulerEnabledSwitch_Toggled;
            HomeOnlyModeSwitch.Toggled += HomeOnlyModeSwitch_Toggled;
        }

        protected void ToggledSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            ICommand cmd = ViewModel.ToggleThingCommand;
            cmd.Execute(ViewModel);
        }

        protected void SchedulerEnabledSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            ICommand cmd = ViewModel.EnableSchedulerCommand;
            cmd.Execute(ViewModel);
        }

        protected void HomeOnlyModeSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            ICommand cmd = ViewModel.ToggleHomeOnlyModeCommand;
            cmd.Execute(ViewModel);
        }
    }
}


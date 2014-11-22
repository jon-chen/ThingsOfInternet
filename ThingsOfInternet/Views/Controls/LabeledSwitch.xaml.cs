using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using ThingsOfInternet.ViewModels;

namespace ThingsOfInternet.Views
{
    public partial class LabeledSwitch : ContentView
    {
        protected SceneViewModel ViewModel
        {
            get { return BindingContext as SceneViewModel; }
        }

        public LabeledSwitch()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            ToggledSwitch.Toggled -= ToggledSwitch_Toggled;

            ToggledSwitch.Toggled += ToggledSwitch_Toggled;
        }

        protected void ToggledSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            ICommand cmd = ViewModel.ToggleSceneCommand;
            cmd.Execute(ViewModel);
        }
    }
}


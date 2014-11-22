using System;
using System.Threading.Tasks;
using ThingsOfInternet.Models;
using ThingsOfInternet.ViewModels;

namespace ThingsOfInternet.Commands
{
    public class ToggleHomeOnlyModeCommand : SparkCoreConfigureCommand
    {
        protected override bool IsBusy
        {
            get { return viewModel.IsHomeOnlyModeEnabledBusy; }
            set { viewModel.IsHomeOnlyModeEnabledBusy = value; }
        }

        protected override string[] PropertiesToSerialize
        {
            get { return new [] { SwitchConfigProperties.IsHomeOnlyModeEnabled }; }
        }

        protected override SwitchConfig SwitchConfig
        {
            get { return null; }
        }

        protected override void RevertValue()
        {
            viewModel.IsHomeOnlyModeEnabled = !viewModel.IsHomeOnlyModeEnabled;
        }
    }
}
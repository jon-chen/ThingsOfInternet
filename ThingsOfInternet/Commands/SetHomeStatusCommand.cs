using System;
using System.Threading.Tasks;
using ThingsOfInternet.Models;
using ThingsOfInternet.Services;
using ThingsOfInternet.ViewModels;
using Unity = Microsoft.Practices.Unity;

namespace ThingsOfInternet.Commands
{
    public class SetHomeStatusCommand : SparkCoreConfigureCommand
    {
        [Unity.Dependency]
        protected ThingsService ThingsService { get; set; }

        #region implemented abstract members of SparkCoreConfigureCommand

        protected override bool IsBusy
        {
            get { return viewModel.IsResetHomeStatusBusy; }
            set { viewModel.IsResetHomeStatusBusy = value; }
        }

        protected override string[] PropertiesToSerialize
        {
            get { return new [] { SwitchConfigProperties.HomeStatus, SwitchConfigProperties.MobileId }; }
        }

        protected override SwitchConfig SwitchConfig
        {
            get 
            { 
                return new SwitchConfig 
                    { 
                        HomeStatus = HomeStatus.Home,
                        MobileId = String.Format("{0:X}", ThingsService.GetMobileIdentifier().GetHashCode())
                    }; 
            }
        }

        protected override void RevertValue()
        {

        }

        #endregion

        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter) && ((ThingViewModel)parameter).IsHomeOnlyModeEnabled;
        }
    }
}
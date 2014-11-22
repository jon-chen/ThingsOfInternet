using System;
using System.Threading.Tasks;
using ThingsOfInternet.Models;
using ThingsOfInternet.ViewModels;
using Unity = Microsoft.Practices.Unity;

namespace ThingsOfInternet.Commands
{
    public class ResetHomeStatusCommand : SparkCoreConfigureCommand
    {
        #region implemented abstract members of SparkCoreConfigureCommand

        protected override bool IsBusy
        {
            get { return viewModel.IsResetHomeStatusBusy; }
            set { viewModel.IsResetHomeStatusBusy = value; }
        }

        protected override string[] PropertiesToSerialize
        {
            get { return new [] { SwitchConfigProperties.HomeStatus }; }
        }

        protected override SwitchConfig SwitchConfig
        {
            get 
            { 
                return new SwitchConfig 
                    { 
                        HomeStatus = HomeStatus.Reset 
                    }; 
            }
        }

        protected override void RevertValue()
        {

        }

        #endregion
    }
}


using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Views;
using ThingsOfInternet.Models;
using ThingsOfInternet.ViewModels;
using Unity = Microsoft.Practices.Unity;

namespace ThingsOfInternet.Commands
{
    public class ShowDetailsCommand : CommandBase
    {
        [Unity.Dependency]
        protected INavigationService NavigationService { get; set; }

        public override bool CanExecute(object parameter)
        {
            return parameter != null && parameter is ThingViewModel;
        }

        public override void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                var viewModel = parameter as ThingViewModel;

                if (viewModel.Model is LightSwitch)
                {
                    NavigationService.NavigateTo(FormsPageKeys.LightSwitchDetailsPageKey, viewModel);
                }
                else if (viewModel.Model is BlindSwitch)
                {
                    NavigationService.NavigateTo(FormsPageKeys.BlindSwitchDetailsPageKey, viewModel);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
using System;
using ThingsOfInternet.ViewModels;
using System.Windows.Input;
using Microsoft.Practices.ServiceLocation;

namespace ThingsOfInternet.Commands
{
    public class ToggleSceneCommand : CommandBase
    {
        public override bool CanExecute(object parameter)
        {
            return parameter is SceneViewModel;
        }

        public override void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                var vm = parameter as SceneViewModel;
                foreach (var thing in vm.Things)
                {
                    thing.IsToggled = vm.IsToggled;
                    IAsyncCommand cmd = ServiceLocator.Current.GetInstance<ToggleThingCommand>();
                    cmd.ExecuteAsync(thing);
                }
            }
        }
    }
}


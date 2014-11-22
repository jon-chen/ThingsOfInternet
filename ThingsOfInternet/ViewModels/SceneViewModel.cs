using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Practices.ServiceLocation;
using ThingsOfInternet.Commands;
using ThingsOfInternet.Models;
using ThingsOfInternet.Services;
using ThingsOfInternet.Utilities;
using Unity = Microsoft.Practices.Unity;
using GalaSoft.MvvmLight.Command;

namespace ThingsOfInternet.ViewModels
{
    public class SceneViewModel : PageViewModelBase
    {
        [Unity.Dependency]
        protected ViewModelLocatorService ViewModelLocatorService { get; set; }

        protected ItemsChangeObservableCollection<ThingViewModel> things;
        protected bool isToggled;
        protected bool isTogglingScene;
        protected ICommand toggleCommand;

        public SceneViewModel(ViewModelLocatorService vmLocatorService, Scene model)
        {
            ViewModelLocatorService = vmLocatorService;

            this.Model = model;

            Things = new ItemsChangeObservableCollection<ThingViewModel>();
            Things.CollectionChanged += (s, e) => 
                {
                    if (!isTogglingScene)
                    {
                        var toggled = Things.Any(x => x.IsToggled);
                        if (IsToggled != toggled)
                        {
                            IsToggled = toggled;
                        }
                    }
                };

            var thingVMs = ViewModelLocatorService.GetThings()
                .Where(x => Model.Things.Contains(x.Model.Id));

            foreach (var vm in thingVMs)
            {
                things.Add(vm);
            }
        }

        public Scene Model 
        { 
            get; 
            private set; 
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

        public ItemsChangeObservableCollection<ThingViewModel> Things
        {
            get { return things; }
            set { Set(() => Things, ref things, value); }
        }

        public bool IsToggled
        {
            get { return isToggled; }
            set { Set(() => IsToggled, ref isToggled, value); }
        }

        public ICommand ToggleSceneCommand
        {
            get 
            { 
                return toggleCommand ?? (toggleCommand = new RelayCommand<SceneViewModel>(p =>
                    {
                        isTogglingScene = true;
                        ICommand cmd = ServiceLocator.Current.GetInstance<ToggleSceneCommand>();
                        cmd.Execute(p);
                        isTogglingScene = false;
                    })); 
            }
        }

        public override void Initialize()
        {
            base.Initialize();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ThingsOfInternet.Services;
using Unity = Microsoft.Practices.Unity;

namespace ThingsOfInternet.ViewModels
{
    public class SceneListViewModel : PageViewModelBase
    {
        [Unity.Dependency]
        protected ViewModelLocatorService ViewModelLocatorService { get; set; }

        public SceneListViewModel(ViewModelLocatorService vmLocatorService)
        {
            ViewModelLocatorService = vmLocatorService;

            NavigationTitle = "My Scenes";
            Items = new ObservableCollection<SceneViewModel>();

            var scenes = ViewModelLocatorService.GetScenes();

            foreach (var item in scenes)
            {
                Items.Add(item);
            }
        }

        public ObservableCollection<SceneViewModel> Items 
        {
            get;
            private set;
        }
    }
}


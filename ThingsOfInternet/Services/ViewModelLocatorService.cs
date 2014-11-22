using System;
using System.Collections.Generic;
using System.Linq;
using ThingsOfInternet.ViewModels;
using Microsoft.Practices.Unity;
using Microsoft.Practices.ServiceLocation;

namespace ThingsOfInternet.Services
{
    public class ViewModelLocatorService : ServiceBase
    {
        [Dependency]
        protected IUnityContainer Container { get; set; }

        [Dependency]
        protected ThingsService ThingsService { get; set; }

        protected IList<ThingViewModel> things;
        protected IList<SceneViewModel> scenes;

        public IList<ThingViewModel> GetThings()
        {
            if (things == null)
            {
                things = ThingsService
                    .GetThings()
                    .Select(x => Container.BuildUp<ThingViewModel>(new ThingViewModel(x)))
                    .ToList();
            }

            return things;
        }

        public IList<SceneViewModel> GetScenes()
        {
            if (scenes == null)
            {
                scenes = ThingsService
                    .GetScenes()
                    .Select(x => Container.BuildUp<SceneViewModel>(new SceneViewModel(Container.Resolve<ViewModelLocatorService>(), x)))
                    .ToList();
            }

            return scenes;
        }
    }
}


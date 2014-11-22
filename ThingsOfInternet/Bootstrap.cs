using System;
using AutoMapper;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Xamarin.Forms.Labs;
using Xamarin.Forms.Labs.Services;
using Xamarin.Forms.Labs.Services.Unity;
using ThingsOfInternet.Commands;
using ThingsOfInternet.Initialization;
using ThingsOfInternet.Logging;
using ThingsOfInternet.Models;
using ThingsOfInternet.Services;
using ThingsOfInternet.ViewModels;
using ThingsOfInternet.Views;

namespace ThingsOfInternet
{
	public static class Bootstrap
	{
		public static void ConfigureContainer(IUnityContainer container)
		{
            // default - new instance per resolve
            // container controlled - singleton

            container.RegisterType<ILogger, DefaultLogger>(new ContainerControlledLifetimeManager());

            container.RegisterType<INavigationService, NavigationService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IDialogService, DialogService>(new ContainerControlledLifetimeManager());

            container.RegisterType<ThingListPage>(new InjectionConstructor(new ResolvedParameter<MainViewModel>()));
            container.RegisterType<SceneListPage>(new InjectionConstructor(new ResolvedParameter<SceneListViewModel>()));

            container.RegisterType<SparkCoreService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IBackgroundService, SparkSubscriberService>("SparkSubscriberService", new ContainerControlledLifetimeManager());
            container.RegisterType<ThingsService>(new ContainerControlledLifetimeManager());
            container.RegisterType<ViewModelLocatorService>(new ContainerControlledLifetimeManager());

            container.RegisterType<IThingService, LightSwitchService>(typeof(LightSwitch).Name);
//            container.RegisterType<IThingService, BlindSwitchService>(typeof(BlindSwitch).Name);

            container.RegisterType<ToggleThingCommand>(new PerResolveLifetimeManager());
		}

        public static void ConfigureNavigation(NavigationService navigation)
        {
            navigation.Configure(FormsPageKeys.LightSwitchDetailsPageKey, typeof(LightSwitchDetailsPage));
            navigation.Configure(FormsPageKeys.BlindSwitchDetailsPageKey, typeof(BlindSwitchDetailsPage));
        }

        public static void RegisterMappings()
        {
            Mapper.Initialize(c =>
                {
                    c.AddProfile<LightSwitchProfile>();
                });
//            Mapper.AssertConfigurationIsValid();
        }
	}
}


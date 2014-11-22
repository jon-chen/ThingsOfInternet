using System;
using Microsoft.Practices.Unity;
using ThingsOfInternet.Ioc;
using ThingsOfInternet.Services;
using Xamarin.Forms.Labs;
using ThingsOfInternet.iOS.Services;

namespace ThingsOfInternet.iOS
{
    public static class Bootstrap
    {
        public static void Configure(IUnityContainer container)
        {
            container.RegisterType<IDevice>(new FactoryLifetimeManager(() => AppleDevice.CurrentDevice));
            container.RegisterType<IDisplay>(new FactoryLifetimeManager(() => container.Resolve<IDevice>().Display));

            container.RegisterType<IGeofenceService, GeofenceService>(new ContainerControlledLifetimeManager());
            container.RegisterType<INotificationService, NotificationService>(new ContainerControlledLifetimeManager());
        }
    }
}
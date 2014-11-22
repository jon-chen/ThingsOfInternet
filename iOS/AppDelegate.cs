using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using ThingsOfInternet.Services;
using Xamarin.Forms;

namespace ThingsOfInternet.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		private UIWindow window;

        public AppDelegate()
        {
            // Initialize bootstrap
            IUnityContainer container = new UnityContainer();
            IServiceLocator locator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => locator);

            ThingsOfInternet.Bootstrap.ConfigureContainer(container);
            iOS.Bootstrap.Configure(container);

            NotificationService = locator.GetInstance<INotificationService>();
            GeofenceService = locator.GetInstance<IGeofenceService>();
        }

        private INotificationService NotificationService { get; set; }
        private IGeofenceService GeofenceService { get; set; }

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			Forms.Init();

            InitializeNativeServices();
            CheckForNotifications(options);

			window = new UIWindow(UIScreen.MainScreen.Bounds);
			
			window.RootViewController = App.GetMainPage().CreateViewController();
			window.MakeKeyAndVisible();

            return true;
		}

        public override void ReceivedLocalNotification(UIApplication application, UILocalNotification notification)
        {
            NotificationService.HandleNotification(notification, true);
        }

        protected void InitializeNativeServices()
        {
            NotificationService.Register();
            GeofenceService.Register();
        }

        protected void CheckForNotifications(NSDictionary options)
        {
            if (options != null && options.ContainsKey(UIApplication.LaunchOptionsLocalNotificationKey))
            {
                var notification = options[UIApplication.LaunchOptionsLocalNotificationKey] as UILocalNotification;
                if (notification != null)
                {
                    NotificationService.HandleNotification(notification, false);
                }
            }
        }
	}
}
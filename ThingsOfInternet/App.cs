using System;
using System.Linq;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Xamarin.Forms;
using ThingsOfInternet.Services;
using ThingsOfInternet.Views;

namespace ThingsOfInternet
{
	public class App
	{
//		private static NavigationPage navigationPage;
        private static TabbedPage mainPage;

		static App()
		{
			Initialize ();
		}

		protected static void Initialize()
		{
            // register AutoMapper mappings
            Bootstrap.RegisterMappings();

            // initialize nav and dialog services
            var navigation = (NavigationService)ServiceLocator.Current.GetInstance<INavigationService>();
            Bootstrap.ConfigureNavigation(navigation);

            mainPage = new TabbedPage();
            mainPage.Children.Add(new NavigationPage(ServiceLocator.Current.GetInstance<ThingListPage>())
                {
                    Title = "Devices",
                    Icon = "cloud-icon.png"// "cloud118.svg"
                });
            mainPage.Children.Add(new NavigationPage(ServiceLocator.Current.GetInstance<SceneListPage>())
                {
                    Title = "Scenes",
                    Icon = "AppIcons29x29.png"// "cloud118.svg"
                });
            mainPage.Children.Add(new NavigationPage(ServiceLocator.Current.GetInstance<SideMenuPage>())
                {
                    Title = "My Home",
                    Icon = "AppIcons29x29.png"// "cloud118.svg"
                });
//            navigationPage = new NavigationPage(ServiceLocator.Current.GetInstance<MainPage>());

                
//            navigationPage.BarBackgroundColor = Color.FromHex("#D2EDFF");
//			navigation.Initialize(navigationPage);
            navigation.Initialize((NavigationPage)mainPage.Children.First());

            var dialog = (DialogService)ServiceLocator.Current.GetInstance<IDialogService>();
//            dialog.Initialize(navigationPage);
            dialog.Initialize(mainPage.Children.First());

            // initialize background services
            var thingsService = ServiceLocator.Current.GetInstance<ThingsService>();
            var things = thingsService.GetThings();

            var subscriber = (SparkSubscriberService)ServiceLocator.Current.GetInstance<IBackgroundService>("SparkSubscriberService");
            subscriber.Initialize(things);
            subscriber.Start();

            var geofence = ServiceLocator.Current.GetInstance<IGeofenceService>();
            geofence.Start();
		}

		public static Page GetMainPage ()
		{	
//			return navigationPage;
            return mainPage;
		}
	}
}


using System;
using MonoTouch.CoreLocation;
using ThingsOfInternet.Services;
using ThingsOfInternet.iOS.Utilities;
using Unity = Microsoft.Practices.Unity;
using GalaSoft.MvvmLight.Messaging;
using ThingsOfInternet.Messaging;

namespace ThingsOfInternet.iOS.Services
{
    public class GeofenceService : ServiceBase, IGeofenceService
    {
        [Unity.Dependency]
        protected INotificationService NotificationService { get; set; }

        [Unity.Dependency]
        protected ThingsService ThingsService { get; set; }

        protected CLLocationManager locationManager;
        protected CLCircularRegion region;

        public bool IsEnabled
        {
            get;
            protected set;
        }

        public void Register()
        {
            locationManager = new CLLocationManager();
            locationManager.RequestAlwaysAuthorization();
        }

        public void Start()
        {
            region = ThingsService
                .GetHomeLocation()
                .AsCircularRegion();

            if (CLLocationManager.IsMonitoringAvailable(typeof(CLCircularRegion))) 
            {
                // Initialize geofence.
                locationManager.DidStartMonitoringForRegion += OnDidStartMonitoringForRegion;
                locationManager.RegionEntered += OnRegionEntered;
                locationManager.RegionLeft += OnRegionLeft;
                locationManager.StartMonitoring(region);

                Logger.Debug("Initializing geofence");

                // Set up location on start up.
                if (locationManager.Location != null)
                {
                    if (region.ContainsCoordinate(locationManager.Location.Coordinate))
                    {
                        OnRegionEntered(this, new CLRegionEventArgs(region));
                    }
                    else
                    {
                        OnRegionLeft(this, new CLRegionEventArgs(region));
                    }
                }

                IsEnabled = true;
            } 
            else 
            {
                Logger.Debug("This app requires region monitoring, which is unavailable on this device");
            }
        }

        public void Stop()
        {
            if (IsEnabled && CLLocationManager.IsMonitoringAvailable(typeof(CLCircularRegion))) 
            {
                locationManager.StopMonitoring(region);
                locationManager.DidStartMonitoringForRegion -= OnDidStartMonitoringForRegion;
                locationManager.RegionEntered -= OnRegionEntered;
                locationManager.RegionLeft -= OnRegionLeft;

                Logger.DebugFormat("Stopped monitoring region: {0}", region.ToString());
            } 
            else 
            {
                Logger.Debug("This app requires region monitoring, which is unavailable on this device");
            }

            IsEnabled = false;
        }

        protected void OnDidStartMonitoringForRegion(object sender, CLRegionEventArgs e)
        {
            Logger.DebugFormat("Now monitoring region {0}", e.Region);
        }

        protected void OnRegionEntered(object sender, CLRegionEventArgs e)
        {
            NotificationService.SendLocal(Constants.App.Title, "You're home!");
            Messenger.Default.Send(new GeofenceEnteredMessage { Name = e.Region.Identifier });
        }

        protected void OnRegionLeft(object sender, CLRegionEventArgs e)
        {
            NotificationService.SendLocal(Constants.App.Title, "You're away!");
            Messenger.Default.Send(new GeofenceLeftMessage { Name = e.Region.Identifier });

        }
    }
}
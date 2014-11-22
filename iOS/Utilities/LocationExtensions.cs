using System;
using MonoTouch.CoreLocation;

namespace ThingsOfInternet.iOS.Utilities
{
    public static class LocationExtensions
    {
        public static CLCircularRegion AsCircularRegion(this Location location)
        {
            var coordinate = new CLLocationCoordinate2D(location.Coordinate.Latitude, location.Coordinate.Longitude);
            return new CLCircularRegion(coordinate, location.Radius, location.Name);
        }
    }
}
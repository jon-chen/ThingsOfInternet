using System;
using ThingsOfInternet.Services;

namespace ThingsOfInternet
{
    public interface IGeofenceService : IBackgroundService
    {
        void Register();
    }
}


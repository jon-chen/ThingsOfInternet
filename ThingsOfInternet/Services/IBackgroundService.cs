using System;

namespace ThingsOfInternet.Services
{
    public interface IBackgroundService
    {
        bool IsEnabled { get; }
        void Start();
        void Stop();
    }
}


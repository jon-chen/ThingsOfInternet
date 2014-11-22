using System;

namespace ThingsOfInternet
{
    // TODO: Implement concrete class
    public interface ISettingsService
    {
        string Get(string key);
        T Get<T>(string key);
        void Set<T>(string key, T value);
    }
}


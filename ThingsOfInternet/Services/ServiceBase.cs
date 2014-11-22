using System;
using ThingsOfInternet.Logging;
using Unity = Microsoft.Practices.Unity;

namespace ThingsOfInternet.Services
{
    public abstract class ServiceBase
    {
        [Unity.Dependency]
        protected ILogger Logger { get; set; }
    }
}
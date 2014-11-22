using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ThingsOfInternet.Models;
using ThingsOfInternet.Services;
using ThingsOfInternet.ViewModels;
using Unity = Microsoft.Practices.Unity;

namespace ThingsOfInternet
{
    public class BlindSwitchService : ServiceBase, IThingService
    {        
        [Unity.Dependency]
        protected SparkCoreService SparkCoreService { get; set; }

        public BlindSwitchService()
        {
        }

        #region IThingService implementation

        public Task ConfigureAsync(ThingViewModel viewModel, ICollection<string> propertiesToSerialize = null)
        {
            throw new NotImplementedException();
        }

        public Task ConfigureAsync(ThingViewModel viewModel, SwitchConfig config, ICollection<string> propertiesToSerialize = null)
        {
            throw new NotImplementedException();
        }

        public Task QueryAsync(ThingViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}


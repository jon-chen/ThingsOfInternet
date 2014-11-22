using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ThingsOfInternet.Models;
using ThingsOfInternet.ViewModels;

namespace ThingsOfInternet.Services
{
    public interface IThingService
    {
        Task ConfigureAsync(ThingViewModel viewModel, ICollection<string> propertiesToSerialize = null);
        Task ConfigureAsync(ThingViewModel viewModel, SwitchConfig config, ICollection<string> propertiesToSerialize = null);
        Task QueryAsync(ThingViewModel viewModel);
    }
}


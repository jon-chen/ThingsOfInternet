using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using ThingsOfInternet.Dtos;
using ThingsOfInternet.Models;
using ThingsOfInternet.Serialization;
using ThingsOfInternet.ViewModels;
using Unity = Microsoft.Practices.Unity;

namespace ThingsOfInternet.Services
{
    public class LightSwitchService : ServiceBase, IThingService
    {
        protected const string SparkCoreConfigureUrl = "https://api.spark.io/v1/devices/{0}/configure";
        protected const string SparkCoreQueryUrl = "https://api.spark.io/v1/devices/{0}/current?access_token={1}";

        [Unity.Dependency]
        protected SparkCoreService SparkCoreService { get; set; }

        public async Task ConfigureAsync(ThingViewModel viewModel, ICollection<string> propertiesToSerialize = null)
        {
            var config = Mapper.Map<SwitchConfig>(viewModel);
            await ConfigureAsync(viewModel, config, propertiesToSerialize);
        }

        public async Task ConfigureAsync(ThingViewModel viewModel, SwitchConfig config, ICollection<string> propertiesToSerialize = null)
        {
            var requestUrl = string.Format(
                SparkCoreConfigureUrl, viewModel.DeviceId);

            var settings = new JsonSerializerSettings();

            if (propertiesToSerialize != null)
            {
                settings.ContractResolver = new DynamicContractResolver(propertiesToSerialize);
            }

            var content = new Dictionary<string, string>
                {
                    { "access_token", Constants.SparkCore.AccessToken },
                    { "params", JsonConvert.SerializeObject(config, settings) }
                };

            await SparkCoreService
                .InvokeAsync(requestUrl, content)
                .ContinueWith(x => ConfigureCallback(viewModel, x.Result));
        }

        protected void ConfigureCallback(ThingViewModel viewModel, SparkFunctionResponse response)
        {

        }

        public async Task QueryAsync(ThingViewModel viewModel)
        {
            var requestUrl = string.Format(
                SparkCoreQueryUrl, viewModel.DeviceId, Constants.SparkCore.AccessToken);

            await SparkCoreService
                .QueryAsync<LightSwitchQuery>(requestUrl)
                .ContinueWith(x => QueryCallback(viewModel, x.Result));
        }

        protected void QueryCallback(ThingViewModel viewModel, LightSwitchQuery response)
        {
            if (response != null)
            {
                Mapper.Map(response, viewModel);
                viewModel.Status = SyncStatus.Synced;
                viewModel.StatusMessage = "OK";
                viewModel.LastUpdated = DateTime.UtcNow;
            }
        }
    }
}
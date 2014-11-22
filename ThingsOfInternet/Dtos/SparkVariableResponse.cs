using System;
using Newtonsoft.Json;

namespace ThingsOfInternet.Dtos
{
    public class SparkVariableResponse
    {
        [JsonProperty("cmd")]
        public string Command { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("result")]
        public string Result { get; set; }
        [JsonProperty("coreInfo")]
        public SparkCoreInfo DeviceInfo { get; set; }
    }
}


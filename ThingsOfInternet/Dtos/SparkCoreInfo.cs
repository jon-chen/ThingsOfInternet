using System;
using Newtonsoft.Json;

namespace ThingsOfInternet.Dtos
{
    [JsonObject]
    public class SparkCoreInfo
    {
        [JsonProperty("last_app")]
        public string LastApp { get; set; }
        [JsonProperty("last_heard")]
        public DateTime LastHeard { get; set; }
        [JsonProperty("connected")]
        public bool Connected { get; set; }
        [JsonProperty("deviceId")]
        public string DeviceId { get; set; }
    }
}


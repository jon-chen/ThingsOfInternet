using System;
using Newtonsoft.Json;

namespace ThingsOfInternet.Dtos
{
    public class SparkFunctionResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("last_app")]
        public string LastApp { get; set; }
        [JsonProperty("connected")]
        public bool Connected { get; set; }
        [JsonProperty("return_value")]
        public int ReturnValue { get; set; }
    }
}


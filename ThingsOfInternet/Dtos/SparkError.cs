using System;
using Newtonsoft.Json;

namespace ThingsOfInternet.Dtos
{
    public class SparkError
    {
        [JsonProperty("ok")]
        public bool Success { get; set; }
        [JsonProperty("error")]
        public string ErrorMessage { get; set; }
    }
}


using System;
using Newtonsoft.Json;

namespace ThingsOfInternet.Dtos
{
    public class SparkEvent
    {
        [JsonProperty("data")]
        public string Data { get; set; }
        [JsonProperty("ttl")]
        public string TimeToLive { get; set; }
        [JsonProperty("published_at")]
        public DateTime PublishedAt { get; set; }
        [JsonProperty("coreid")]
        public string CoreId { get; set; }
    }
}


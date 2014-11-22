using System;
using Newtonsoft.Json;

namespace ThingsOfInternet.Models
{
    [JsonObject]
    public class SwitchSchedulerTask
    {
        [JsonProperty("startTime")]
        public string StartTime { get; set; } 
        [JsonProperty("endTime")]
        public string EndTime { get; set; }
    }
}


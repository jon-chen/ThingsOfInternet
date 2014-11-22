using System;
using Newtonsoft.Json;

namespace ThingsOfInternet.Models
{
    public class SwitchConfig
    {
        [JsonProperty(SwitchConfigProperties.IsToggled)]
        public bool? IsToggled { get; set; }
        [JsonProperty(SwitchConfigProperties.TimezoneOffset)]
        public int? TimezoneOffset { get; set; }
        [JsonProperty(SwitchConfigProperties.SunsetApiUrl)]
        public string SunsetApiUrl { get; set; }
        [JsonProperty(SwitchConfigProperties.SunsetApiCheckTime)]
        public string SunsetApiCheckTime { get; set; }
        [JsonProperty(SwitchConfigProperties.IsSchedulerEnabled)]
        public bool? IsSchedulerEnabled { get; set; }
        [JsonProperty(SwitchConfigProperties.IsHomeOnlyModeEnabled)]
        public bool? IsHomeOnlyModeEnabled { get; set; }
        [JsonProperty(SwitchConfigProperties.HomeStatus)]
        public HomeStatus? HomeStatus { get; set; }
        [JsonProperty(SwitchConfigProperties.MobileId)]
        public string MobileId { get; set; }
    }

    public static class SwitchConfigProperties
    {
        public const string IsToggled = "IsToggled";
        public const string TimezoneOffset = "TimezoneOffset";
        public const string SunsetApiUrl = "SunsetApiUrl";
        public const string SunsetApiCheckTime = "SunsetApiCheckTime";
        public const string IsSchedulerEnabled = "IsSchedulerEnabled";
        public const string IsHomeOnlyModeEnabled = "IsHomeOnlyModeEnabled";
        public const string HomeStatus = "HomeStatus";
        public const string MobileId = "MobileId";
    }
}
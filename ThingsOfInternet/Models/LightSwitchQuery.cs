using System;
using Newtonsoft.Json;

namespace ThingsOfInternet.Models
{
    public class LightSwitchQuery
    {
//        [JsonProperty(LightSwitchQueryProperties.DeviceTime)]
//        public DateTime DeviceTime { get; set; }
        [JsonProperty(LightSwitchQueryProperties.Schedules)]
        public SwitchSchedulerTask[] Schedules { get; set; }
        [JsonProperty(LightSwitchQueryProperties.UseAstronomyData)]
        public bool UseAstronomyData { get; set; }
//        [JsonProperty(LightSwitchQueryProperties.SunsetTime)]
//        public DateTime SunsetTime { get; set; }
//        [JsonProperty(LightSwitchQueryProperties.SunriseTime)]
//        public DateTime SunriseTime { get; set; }
        [JsonProperty(LightSwitchQueryProperties.TimezoneOffset)]
        public int TimezoneOffset { get; set; }
        [JsonProperty(LightSwitchQueryProperties.CurrentSwitchState)]
        public bool CurrentSwitchState { get; set; }
        [JsonProperty(LightSwitchQueryProperties.ShouldSwitchBeToggled)]
        public bool ShouldSwitchBeToggled { get; set; }
        [JsonProperty(LightSwitchQueryProperties.IsSchedulerEnabled)]
        public bool IsSchedulerEnabled { get; set ; }
        [JsonProperty(LightSwitchQueryProperties.IsHomeOnlyModeEnabled)]
        public bool IsHomeOnlyModeEnabled { get; set; }
        [JsonProperty(LightSwitchQueryProperties.CurrentHomeCount)]
        public int CurrentHomeCount { get; set; }
    }

    public static class LightSwitchQueryProperties
    {
        public const string DeviceTime = "time";
        public const string Schedules = "schedules";
        public const string UseAstronomyData = "useAstronomyData";
        public const string SunsetTime = "sunsetTime";
        public const string SunriseTime = "sunriseTime";
        public const string TimezoneOffset = "timezoneOffset";
        public const string CurrentSwitchState = "currentSwitchState";
        public const string ShouldSwitchBeToggled = "shouldSwitchBeToggled";
        public const string IsSchedulerEnabled = "isSchedulerEnabled";
        public const string IsHomeOnlyModeEnabled = "isHomeOnlyModeEnabled";
        public const string CurrentHomeCount = "currentHomeCount";
    }
}
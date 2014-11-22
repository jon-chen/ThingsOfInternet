using System;

namespace ThingsOfInternet.Models
{
    public class LightSwitch : IThing
    {
        public Guid Id { get; set; }
        public string Category { get { return "Light Switch"; } }
        public string DisplayName { get; set; }
        public string DeviceId { get; set; }
        public int CurrentHomeCount { get; set; }
        public bool IsSchedulerEnabled { get; set; }
        public bool IsHomeOnlyModeEnabled { get; set; }
        public bool IsToggled { get; set; }
        public SyncStatus Status { get; set; }
        public SyncStatus MessageBusStatus { get; set; }
        public string StatusMessage { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}


using System;

namespace ThingsOfInternet.Models
{
    public interface IThing
    {
        Guid Id { get; set; }
        string Category { get; }
        string DisplayName { get; set; }
        string DeviceId { get; set; }
        int CurrentHomeCount { get; set; }
        bool IsSchedulerEnabled { get; set; }
        bool IsHomeOnlyModeEnabled { get; set; }
        bool IsToggled { get; set; }
        SyncStatus Status { get; set; }
        SyncStatus MessageBusStatus { get; set; }
        string StatusMessage { get; set; }
        DateTime LastUpdated { get; set; }
    }
}


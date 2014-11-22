using System;
using ThingsOfInternet.Models;

namespace ThingsOfInternet.Messaging
{
    public class SparkCoreStatusMessage : SparkCoreMessage
    {
        public SyncStatus Status { get; set; }
    }
}


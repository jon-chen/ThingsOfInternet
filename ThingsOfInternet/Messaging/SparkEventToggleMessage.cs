using System;

namespace ThingsOfInternet.Messaging
{
    public class SparkEventToggleMessage : SparkCoreMessage
    {
        public bool ToggleState { get; set; }
    }
}


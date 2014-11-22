using System;

namespace ThingsOfInternet.Logging
{
    public interface ILogger
    {
        void Info(string value);
        void InfoFormat(string value, params object[] args);
        void Debug(string value);
        void DebugFormat(string value, params object[] args);
        void Error(string value);
        void Error(string value, Exception e);
        void ErrorFormat(string value, params object[] args);
        void ErrorFormat(Exception e, string value, params object[] args);
    }
}


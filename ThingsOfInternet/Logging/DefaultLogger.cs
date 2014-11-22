using System;

namespace ThingsOfInternet.Logging
{
    public class DefaultLogger : ILogger
    {
        #region ILogger implementation

        public void Info(string value)
        {
            System.Diagnostics.Debug.WriteLine(value);
        }

        public void InfoFormat(string value, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine(value, args);
        }

        public void Debug(string value)
        {
            System.Diagnostics.Debug.WriteLine(value);
        }

        public void DebugFormat(string value, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine(value, args);
        }

        public void Error(string value)
        {
            System.Diagnostics.Debug.WriteLine(value);
        }

        public void Error(string value, Exception e)
        {
            System.Diagnostics.Debug.WriteLine(value);
            System.Diagnostics.Debug.WriteLine(e);
        }

        public void ErrorFormat(string value, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine(value, args);
        }

        public void ErrorFormat(Exception e, string value, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine(value, args);
            System.Diagnostics.Debug.WriteLine(e);
        }

        #endregion
    }
}


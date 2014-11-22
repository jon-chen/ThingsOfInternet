using System;

namespace ThingsOfInternet
{
    public class WebServiceException : Exception
    {
        public WebServiceException() : base()
        {
        }

        public WebServiceException(string message) : base(message)
        {
        }

        public WebServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}


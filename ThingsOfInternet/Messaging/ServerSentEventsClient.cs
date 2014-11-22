using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ThingsOfInternet.Messaging
{
    public class ServerSentEventsClient : IDisposable
    {
        protected const string SuccessStatus = ":ok";
        protected const string EventMessage = "event: ";
        protected const string DataMessage = "data: ";

        public event EventHandler Connected = delegate { };
        public event EventHandler<ServerSideEventEventArgs> MessageReceived = delegate { };

        protected HttpClient client;
        protected ServerSideEvent currentEvent;

        public string Name
        {
            get;
            protected set;
        }

        public ServerSentEventsClient() : this(string.Empty)
        {

        }

        public ServerSentEventsClient(string name)
        {
            this.Name = name;
        }

        public void Connect<TResponse>(string requestUrl)
        {
            client = new HttpClient();
            client.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);

            Task.Factory.StartNew(async () =>
                {
                    // TODO: exception handling
                    // TODO: Timeout handling
                    var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                    var stream = await response.Content.ReadAsStreamAsync();

                    using (var reader = new StreamReader(stream))
                    {
                        while (!reader.EndOfStream) 
                        { 
                            var line = await reader.ReadLineAsync();

                            if (!string.IsNullOrWhiteSpace(line))
                            {
                                if (line == SuccessStatus)
                                {
                                    Connected(this, EventArgs.Empty);
                                }
                                else if (line.StartsWith(EventMessage))
                                {
                                    currentEvent = new ServerSideEvent<TResponse>();
                                    currentEvent.EventName = line.Substring(EventMessage.Length);
                                }
                                else if (line.StartsWith(DataMessage))
                                {
                                    currentEvent.Data = JsonConvert.DeserializeObject<TResponse>(line.Substring(DataMessage.Length));
                                    MessageReceived(this, new ServerSideEventEventArgs(currentEvent));
                                }
                            }
                        }
                    }
                });
        }

        #region IDisposable implementation

        public void Dispose()
        {
            if (client != null)
            {
                client.Dispose();
                client = null;
            }
        }

        #endregion
    }

    public class ServerSideEventEventArgs : EventArgs
    {
        public ServerSideEvent Message { get; protected set; }

        public ServerSideEventEventArgs(ServerSideEvent message)
        {
            this.Message = message;
        }
    }

    public class ServerSideEvent
    {
        public string EventName { get; set; }
        public object Data { get; set; }
    }

    public class ServerSideEvent<T> : ServerSideEvent
    {
        public new T Data
        {
            get { return (T)base.Data; }
            set { base.Data = value; }
        }
    }
}


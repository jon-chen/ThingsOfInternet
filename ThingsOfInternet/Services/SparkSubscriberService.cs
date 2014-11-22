using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Messaging;
using ThingsOfInternet.Dtos;
using ThingsOfInternet.Logging;
using ThingsOfInternet.Messaging;
using ThingsOfInternet.Models;

namespace ThingsOfInternet.Services
{
    public class SparkSubscriberService : ServiceBase, IBackgroundService
    {
        protected const string SparkEventsUrl = "https://api.spark.io/v1/devices/{0}/events/?access_token={1}";
        protected IList<ServerSentEventsClient> clients;
        protected IList<IThing> things;

        public bool IsEnabled
        {
            get;
            protected set;
        }

        public void Initialize(IList<IThing> things)
        {
            this.things = things;
        }

        public void Start()
        {
            Stop();

            clients = new List<ServerSentEventsClient>();

            foreach (var thing in things)
            {
                if (!string.IsNullOrWhiteSpace(thing.DeviceId))
                {
                    var client = new ServerSentEventsClient(thing.DeviceId);
                    client.Connected += OnConnected;
                    client.MessageReceived += OnMessageReceived;
                    client.Connect<SparkEvent>(string.Format(SparkEventsUrl, thing.DeviceId, Constants.SparkCore.AccessToken));
                    clients.Add(client);

                    SendStatusMessage(thing.DeviceId, SyncStatus.Syncing);
                }
            }

            IsEnabled = true;
        }

        protected void OnConnected(object sender, EventArgs e)
        {
            var client = sender as ServerSentEventsClient;
            SendStatusMessage(client.Name, SyncStatus.Synced);
            Logger.DebugFormat("{0}: Connected!", client.Name);
        }

        protected void OnMessageReceived(object sender, ServerSideEventEventArgs e)
        {
            var client = sender as ServerSentEventsClient;
            Logger.DebugFormat("{0}: Message Received!", client.Name);

            var message = e.Message as ServerSideEvent<SparkEvent>;
            if (message.EventName == "ToggleState")
            {
                SendToggleMessage(message.Data);
            }
        }

        protected void SendStatusMessage(string deviceId, SyncStatus status)
        {
            Messenger.Default.Send(new SparkCoreStatusMessage
                {
                    DeviceId = deviceId,
                    Status = status
                });
        }

        protected void SendToggleMessage(SparkEvent evt)
        {
            Messenger.Default.Send(new SparkEventToggleMessage
                {
                    DeviceId = evt.CoreId,
                    ToggleState = Convert.ToBoolean(evt.Data)
                });
        }

        public void Stop()
        {
            if (clients != null)
            {
                foreach (var client in clients)
                {
                    client.Connected -= OnConnected;
                    client.MessageReceived -= OnMessageReceived;
                    client.Dispose();
                }

                clients.Clear();
            }
            IsEnabled = false;
        }
    }
}


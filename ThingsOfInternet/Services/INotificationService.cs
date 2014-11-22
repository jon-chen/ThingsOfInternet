using System;

namespace ThingsOfInternet.Services
{
    public interface INotificationService
    {
        void Register();
        void SendLocal(string title, string content, TimeSpan fromNow = default(TimeSpan));
        void HandleNotification(object notification, bool showAlert);
    }
}


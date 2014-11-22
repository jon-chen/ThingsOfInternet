using System;
using GalaSoft.MvvmLight.Views;
using MonoTouch.UIKit;
using ThingsOfInternet.Services;
using Unity = Microsoft.Practices.Unity;

namespace ThingsOfInternet.iOS.Services
{
    public class NotificationService : INotificationService
    {
        [Unity.Dependency]
        protected IDialogService DialogService { get; set; }

        #region INotificationService implementation

        public void Register()
        {
            UIUserNotificationType userNotificationTypes = UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound;
            UIUserNotificationSettings settings = UIUserNotificationSettings.GetSettingsForTypes(userNotificationTypes, null);
            UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
        }

        public void SendLocal(string title, string content, TimeSpan fromNow = default(TimeSpan))
        {
            var notification = new UILocalNotification
                {
                    AlertAction = title,
                    AlertBody = content,
                    FireDate = DateTime.Now.Add(fromNow),
                    ApplicationIconBadgeNumber = UIApplication.SharedApplication.ApplicationIconBadgeNumber + 1,
                    SoundName = UILocalNotification.DefaultSoundName
                };
            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
        }

        public void HandleNotification(object notification, bool showAlert)
        {
            var localNotification = notification as UILocalNotification;

            if (showAlert)
            {
                DialogService.ShowMessage(localNotification.AlertBody, localNotification.AlertAction);
            }

            UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
        }

        #endregion
    }
}
using System.Collections.Generic;
using Tunes.Business.Notifications;

namespace Tunes.Business.Interfaces
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
using RestSharp;

namespace TrelloNet.Internal
{
    internal class NotificationChangeUnreadRequest : NotificationsRequest
    {
        public NotificationChangeUnreadRequest(INotificationId notification, bool unread)
            : base(notification, "unread", Method.PUT)
        {
            this.AddValue(unread ? "true" : "false");
        }

    }
}
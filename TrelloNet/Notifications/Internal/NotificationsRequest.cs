using RestSharp;

namespace TrelloNet.Internal
{
    internal class NotificationsRequest : RestRequest
    {
        public NotificationsRequest(INotificationId notificationId, string resource = "", Method method = Method.GET)
            : base("notifications/{notificationId}/" + resource, method)
        {
            AddParameter("notificationId", notificationId.GetNotificationId(), ParameterType.UrlSegment);
        }

        public NotificationsRequest(string notificationId, string resource = "", Method method = Method.GET)
            : this(new NotificationId(notificationId), resource, method)
        {
        }
    }
}
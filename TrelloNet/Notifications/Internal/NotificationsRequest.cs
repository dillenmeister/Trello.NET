using RestSharp;

namespace TrelloNet.Internal
{
	internal class NotificationsRequest : RestRequest
	{
		public NotificationsRequest(INotificationId notificationId, string resource = "")
			: base("notifications/{notificationId}/" + resource)
		{
			AddParameter("notificationId", notificationId.GetNotificationId(), ParameterType.UrlSegment);
		}

		public NotificationsRequest(string notificationId, string resource = "")
			: this(new NotificationId(notificationId), resource)
		{
		}
	}
}
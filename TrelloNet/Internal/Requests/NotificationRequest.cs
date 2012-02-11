using RestSharp;

namespace TrelloNet.Internal.Requests
{
	internal class NotificationRequest : RestRequest
	{
		public NotificationRequest(INotificationId notificationId, string resource = "")
			: base("notifications/{notificationId}/" + resource)
		{
			AddParameter("notificationId", notificationId.GetNotificationId(), ParameterType.UrlSegment);
		}

		public NotificationRequest(string notificationId, string resource = "")
			: this(new NotificationId(notificationId), resource)
		{
		}
	}
}
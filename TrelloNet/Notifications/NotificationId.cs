using TrelloNet.Internal;

namespace TrelloNet
{
	public class NotificationId : INotificationId
	{
		private readonly string _notificationId;

		public NotificationId(string notificationId)
		{
			Guard.NotNullOrEmpty(notificationId, "notificationId");
			_notificationId = notificationId;
		}

		public string GetNotificationId()
		{
			return _notificationId;
		}
	}
}
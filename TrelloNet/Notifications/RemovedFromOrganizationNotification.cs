namespace TrelloNet
{
	public class RemovedFromOrganizationNotification : Notification
	{
		public NotificationData Data { get; set; }

		public class NotificationData
		{
			public OrganizationName Organization { get; set; }
		}
	}
}
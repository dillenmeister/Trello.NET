namespace TrelloNet
{
	public class InvitedToOrganizationNotification : Notification
	{
		public NotificationData Data { get; set; }

		public class NotificationData
		{
			public OrganizationName Organization { get; set; }
		}
	}
}
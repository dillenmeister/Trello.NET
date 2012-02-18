namespace TrelloNet
{
	public class AddAdminToOrganization : Notification
	{
		public NotificationData Data { get; set; }

		public class NotificationData
		{
			public OrganizationName Organization { get; set; }
		}
	}
}
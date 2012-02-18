namespace TrelloNet
{
	public class CloseBoardNotification : Notification
	{
		public NotificationData Data { get; set; }

		public class NotificationData
		{
			public BoardName Board { get; set; }
		}
	}
}
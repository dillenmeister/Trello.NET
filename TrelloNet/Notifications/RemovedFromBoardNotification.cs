namespace TrelloNet
{
	public class RemovedFromBoardNotification : Notification
	{
		public NotificationData Data { get; set; }

		public class NotificationData
		{
			public BoardName Board { get; set; }
		}
	}
}
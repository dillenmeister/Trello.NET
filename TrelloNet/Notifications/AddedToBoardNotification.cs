namespace TrelloNet
{
	public class AddedToBoardNotification : Notification
	{
		public NotificationData Data { get; set; }

		public class NotificationData
		{
			public BoardName Board { get; set; }
		}		
	}
}
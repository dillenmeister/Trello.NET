namespace TrelloNet
{
	public class RemovedFromCardNotification : Notification
	{
		public NotificationData Data { get; set; }

		public class NotificationData
		{
			public BoardName Board { get; set; }
			public CardName Card { get; set; }
		}
	}
}
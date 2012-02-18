namespace TrelloNet
{
	public class ChangeCardNotification : Notification
	{
		public NotificationData Data { get; set; }

		public class NotificationData
		{
			public CardName Card { get; set; }
			public BoardName Board { get; set; }
		}
	}
}
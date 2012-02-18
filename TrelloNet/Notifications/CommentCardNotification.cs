namespace TrelloNet
{
	public class CommentCardNotification : Notification
	{
		public NotificationData Data { get; set; }

		public class NotificationData
		{
			public CardName Card { get; set; }
			public BoardName Board { get; set; }
			public string Text { get; set; }
		}
	}
}
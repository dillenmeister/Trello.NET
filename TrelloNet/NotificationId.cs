namespace TrelloNet
{
	public class NotificationId : INotificationId
	{
		private readonly string _id;

		public NotificationId(string id)
		{
			_id = id;
		}

		public string GetNotificationId()
		{
			return _id;
		}
	}
}
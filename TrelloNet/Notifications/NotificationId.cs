using TrelloNet.Internal;

namespace TrelloNet
{
	public class NotificationId : INotificationId
	{
		private readonly string _id;

		public NotificationId(string id)
		{
			Guard.NotNullOrEmpty(id, "id");
			_id = id;
		}

		public string Id
		{
			get { return _id; }
		}

		public string GetNotificationId()
		{
			return Id;
		}
	}
}
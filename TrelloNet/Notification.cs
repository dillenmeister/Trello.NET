using System;
using TrelloNet.Internal;

namespace TrelloNet
{
	public class Notification : INotificationId
	{
		public string Id { get; set; }
		public bool Unread { get; set; }
		public DateTime Date { get; set; }
		public string IdMemberCreator { get; set; }
		public NotificationType Type { get; set; }
		public dynamic Data { get; set; }

		public string GetNotificationId()
		{
			return Id;
		}
	}
}
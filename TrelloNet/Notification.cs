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

		public string GetNotificationId()
		{
			return Id;
		}
	}

	public class AddedToCardNotification : Notification
	{
		public NotificationData Data { get; set; }

		public class NotificationData
		{
			public BoardDisplay Board { get; set; }					
		}
	}

	public class BoardDisplay
	{
		public string Id { get; set; }
		public string Name { get; set; }
	}
}
using System;

namespace TrelloNet
{
	public class Notification : INotificationId
	{
		public string Id { get; set; }
		public bool Unread { get; set; }
		public DateTime Date { get; set; }
		public string IdMemberCreator { get; set; }	

		public string GetNotificationId()
		{
			return Id;
		}
	}
}
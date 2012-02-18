using System.Collections.Generic;
using TrelloNet.Internal;

namespace TrelloNet
{
	public interface INotifications
	{
		Notification WithId(string notificationId);
		IEnumerable<Notification> ForMe(IEnumerable<NotificationType> types = null, ReadFilter readFilter = ReadFilter.Default, Paging paging = null);
	}
}
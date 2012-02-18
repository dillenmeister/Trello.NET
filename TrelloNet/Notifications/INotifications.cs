using System.Collections.Generic;
using TrelloNet.Internal;

namespace TrelloNet
{
	public interface INotifications
	{
		Notification GetById(string notificationId);
		IEnumerable<Notification> GetByMe(IEnumerable<NotificationType> types = null, ReadFilter readFilter = ReadFilter.Default, Paging paging = null);
	}
}
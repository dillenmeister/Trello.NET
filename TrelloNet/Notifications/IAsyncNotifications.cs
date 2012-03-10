using System.Collections.Generic;
using System.Threading.Tasks;
using TrelloNet.Internal;

namespace TrelloNet
{
	public interface IAsyncNotifications
	{
		Task<Notification> WithId(string notificationId);
		Task<IEnumerable<Notification>> ForMe(IEnumerable<NotificationType> types = null, ReadFilter readFilter = ReadFilter.Default, Paging paging = null);
	}
}
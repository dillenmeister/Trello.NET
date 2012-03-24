using System.Collections.Generic;
using System.Threading.Tasks;
using TrelloNet.Internal;

namespace TrelloNet
{
	public interface IAsyncNotifications
	{
		/// <summary>
		/// GET /notifications/[notification_id]
		/// </summary>
		Task<Notification> WithId(string notificationId);

		/// <summary>
		/// GET /members/[member_id or username]/notifications
		/// </summary>
		Task<IEnumerable<Notification>> ForMe(IEnumerable<NotificationType> types = null, ReadFilter readFilter = ReadFilter.Default, Paging paging = null);
	}
}
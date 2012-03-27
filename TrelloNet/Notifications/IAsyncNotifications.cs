using System.Collections.Generic;
using System.Threading.Tasks;
using TrelloNet.Internal;

namespace TrelloNet
{
	public interface IAsyncNotifications
	{
		/// <summary>
		/// GET /notifications/[notification_id]
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Task<Notification> WithId(string notificationId);

		/// <summary>
		/// GET /members/[member_id or username]/notifications
		/// <br/>
		/// Required permissions: read, own
		/// You can only read the notifications for the member associated with the supplied token.
		/// </summary>
		Task<IEnumerable<Notification>> ForMe(IEnumerable<NotificationType> types = null, ReadFilter readFilter = ReadFilter.All, Paging paging = null);
	}
}
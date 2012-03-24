using System.Collections.Generic;
using TrelloNet.Internal;

namespace TrelloNet
{
	public interface INotifications
	{
		/// <summary>
		/// GET /notifications/[notification_id]
		/// </summary>
		Notification WithId(string notificationId);

		/// <summary>
		/// GET /members/[member_id or username]/notifications
		/// </summary>
		IEnumerable<Notification> ForMe(IEnumerable<NotificationType> types = null, ReadFilter readFilter = ReadFilter.Default, Paging paging = null);
	}
}
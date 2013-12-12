using System.Collections.Generic;
using TrelloNet.Internal;

namespace TrelloNet
{
	public interface INotifications
	{
		/// <summary>
		/// GET /notifications/[notification_id]
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Notification WithId(string notificationId);

		/// <summary>
		/// GET /members/[member_id or username]/notifications
		/// <br/>
		/// Required permissions: read, own
		/// You can only read the notifications for the member associated with the supplied token.
		/// </summary>
		IEnumerable<Notification> ForMe(IEnumerable<NotificationType> types = null, ReadFilter readFilter = ReadFilter.All, Paging paging = null);

        /// <summary>
        /// PUT /notifications/[idNotification]/unread
        /// <br/>
        /// Required permissions: write
        /// </summary>
	    void ChangeUnread(INotificationId notification, bool unread);
	}
}
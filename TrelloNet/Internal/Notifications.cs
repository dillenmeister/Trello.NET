using System.Collections.Generic;
using TrelloNet.Internal.Requests;

namespace TrelloNet.Internal
{
	internal class Notifications : INotifications
	{
		private readonly TrelloRestClient _restClient;

		public Notifications(TrelloRestClient restClient)
		{
			_restClient = restClient;
		}

		public Notification GetById(string notificationId)
		{
			Guard.NotNullOrEmpty(notificationId, "notificationId");
			return _restClient.Request<Notification>(new NotificationRequest(notificationId));
		}

		public IEnumerable<Notification> GetByMe(IEnumerable<NotificationType> types = null, ReadFilter readFilter = ReadFilter.Default, Paging paging = null)
		{
			return _restClient.Request<List<Notification>>(new MemberNotificationRequest(new Me(), types, readFilter, paging));
		}
	}
}
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrelloNet.Internal
{
	internal class AsyncNotifications : IAsyncNotifications
	{
		private readonly TrelloRestClient _restClient;

		public AsyncNotifications(TrelloRestClient restClient)
		{
			_restClient = restClient;
		}

		public Task<Notification> WithId(string notificationId)
		{
			return _restClient.RequestAsync<Notification>(new NotificationsRequest(notificationId));
		}

		public Task<IEnumerable<Notification>> ForMe(IEnumerable<NotificationType> types = null, ReadFilter readFilter = ReadFilter.Default, Paging paging = null)
		{
			return _restClient.RequestListAsync<Notification>(new NotificationsForMeRequest(new Me(), types, readFilter, paging));
		}
	}
}
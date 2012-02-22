using System.Collections.Generic;

namespace TrelloNet.Internal
{
	internal class NotificationsForMeRequest : MembersRequest
	{
		public NotificationsForMeRequest(IMemberId member, IEnumerable<NotificationType> filter, ReadFilter readFilter, Paging paging)
			: base(member, "notifications")
		{
			this.AddFilter(filter);
			this.AddFilter(readFilter, "read_filter");
			this.AddPaging(paging);
		}
	}
}
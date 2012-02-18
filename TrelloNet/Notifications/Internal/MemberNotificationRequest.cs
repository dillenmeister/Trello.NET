using System.Collections.Generic;

namespace TrelloNet.Internal
{
	internal class MemberNotificationRequest : MemberRequest
	{
		public MemberNotificationRequest(IMemberId member, IEnumerable<NotificationType> filter, ReadFilter readFilter, Paging paging)
			: base(member, "notifications")
		{
			this.AddFilter(filter);
			this.AddFilter(readFilter, "read_filter");
			this.AddPaging(paging);
		}
	}
}
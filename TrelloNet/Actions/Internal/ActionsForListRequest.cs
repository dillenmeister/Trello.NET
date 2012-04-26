using System.Collections.Generic;

namespace TrelloNet.Internal
{
	internal class ActionsForListRequest : ListsRequest
	{
		public ActionsForListRequest(IListId list, ISince since, Paging paging, IEnumerable<ActionType> filter)
			: base(list, "actions")
		{
			this.AddTypeFilter(filter);
			this.AddSince(since);
			this.AddPaging(paging);
		}
	}
}
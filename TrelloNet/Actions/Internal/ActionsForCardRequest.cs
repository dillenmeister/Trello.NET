using System.Collections.Generic;

namespace TrelloNet.Internal
{
	internal class ActionsForCardRequest : CardsRequest
	{
		public ActionsForCardRequest(ICardId card, ISince since, Paging paging, IEnumerable<ActionType> filter)
			: base(card, "actions")
		{
			this.AddTypeFilter(filter);
			this.AddSince(since);
			this.AddPaging(paging);
		}
	}
}
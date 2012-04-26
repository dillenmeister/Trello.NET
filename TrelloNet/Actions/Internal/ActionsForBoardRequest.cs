using System.Collections.Generic;

namespace TrelloNet.Internal
{
	internal class ActionsForBoardRequest : BoardsRequest
	{
		public ActionsForBoardRequest(IBoardId board, ISince since, Paging paging, IEnumerable<ActionType> types)
			: base(board, "actions")
		{
			this.AddTypeFilter(types);
			this.AddSince(since);
			this.AddPaging(paging);
		}		
	}
}
using System;

namespace TrelloNet.Internal
{
	internal class ActionsForBoardRequest : BoardsRequest
	{
		public ActionsForBoardRequest(IBoardId board, ISince since, Paging paging)
			: base(board, "actions")
		{			
			if(since != null)
			{
				if (since.LastView)
					AddParameter("since", "lastView");
				if (since.Date > DateTime.MinValue)
					AddParameter("since", since.Date);
			}

			this.AddPaging(paging);
		}
	}
}
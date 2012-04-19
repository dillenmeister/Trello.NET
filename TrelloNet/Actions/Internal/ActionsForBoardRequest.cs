namespace TrelloNet.Internal
{
	internal class ActionsForBoardRequest : BoardsRequest
	{
		public ActionsForBoardRequest(IBoardId board, ISince since, Paging paging)
			: base(board, "actions")
		{
			this.AddSince(since);
			this.AddPaging(paging);
		}		
	}
}
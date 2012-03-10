namespace TrelloNet.Internal
{
	internal class ChecklistsForBoardRequest : BoardsRequest
	{
		public ChecklistsForBoardRequest(IBoardId board)
			: base(board, "checklists")
		{
		}
	}
}
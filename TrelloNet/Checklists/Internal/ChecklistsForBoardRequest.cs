namespace TrelloNet.Internal
{
	internal class ChecklistsForBoardRequest : BoardsRequest
	{
		public ChecklistsForBoardRequest(IBoardId boardId)
			: base(boardId, "checklists")
		{
		}
	}
}
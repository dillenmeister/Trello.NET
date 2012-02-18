namespace TrelloNet.Internal
{
	internal class BoardChecklistsRequest : BoardRequest
	{
		public BoardChecklistsRequest(IBoardId boardId)
			: base(boardId, "checklists")
		{
		}
	}
}
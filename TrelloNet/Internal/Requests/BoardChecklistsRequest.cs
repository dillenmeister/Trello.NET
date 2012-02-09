namespace TrelloNet.Internal.Requests
{
	internal class BoardChecklistsRequest : BoardRequest
	{
		public BoardChecklistsRequest(IBoardId boardId)
			: base(boardId, "checklists")
		{
		}
	}
}
namespace TrelloNet.Internal.Requests
{
	internal class BoardChecklistsRequest : BoardRequest
	{
		public BoardChecklistsRequest(string boardId)
			: base(boardId, "checklists")
		{
		}
	}
}
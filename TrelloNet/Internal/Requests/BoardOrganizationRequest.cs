namespace TrelloNet.Internal.Requests
{
	internal class BoardOrganizationRequest : BoardRequest
	{
		public BoardOrganizationRequest(IBoardId boardId)
			: base(boardId, "organization")
		{
		}
	}
}
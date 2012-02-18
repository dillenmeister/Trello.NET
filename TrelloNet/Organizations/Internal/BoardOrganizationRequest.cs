namespace TrelloNet.Internal
{
	internal class BoardOrganizationRequest : BoardRequest
	{
		public BoardOrganizationRequest(IBoardId boardId)
			: base(boardId, "organization")
		{
		}
	}
}
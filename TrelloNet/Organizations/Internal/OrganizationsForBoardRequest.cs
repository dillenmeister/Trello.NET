namespace TrelloNet.Internal
{
	internal class OrganizationsForBoardRequest : BoardsRequest
	{
		public OrganizationsForBoardRequest(IBoardId boardId)
			: base(boardId, "organization")
		{
		}
	}
}
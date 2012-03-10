namespace TrelloNet.Internal
{
	internal class OrganizationsForBoardRequest : BoardsRequest
	{
		public OrganizationsForBoardRequest(IBoardId board)
			: base(board, "organization")
		{
		}
	}
}
namespace TrelloNet.Internal.Requests
{
	internal class BoardOrganizationRequest : BoardRequest
	{
		public BoardOrganizationRequest(string boardId) : base(boardId, "organization")
		{			
		}
	}
}
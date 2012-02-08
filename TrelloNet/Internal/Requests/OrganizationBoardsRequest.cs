namespace TrelloNet.Internal.Requests
{
	internal class OrganizationBoardsRequest : OrganizationRequest
	{
		public OrganizationBoardsRequest(string orgIdOrName, BoardFilter filter)
			: base(orgIdOrName, "boards")
		{
			this.AddFilter(filter);
		}
	}
}
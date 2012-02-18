namespace TrelloNet.Internal
{
	internal class OrganizationBoardsRequest : OrganizationRequest
	{
		public OrganizationBoardsRequest(IOrganizationId orgIdOrName, BoardFilter filter)
			: base(orgIdOrName, "boards")
		{
			this.AddFilter(filter);
		}
	}
}
namespace TrelloNet.Internal
{
	internal class BoardsForOrganizationRequest : OrganizationsRequest
	{
		public BoardsForOrganizationRequest(IOrganizationId orgIdOrName, BoardFilter filter)
			: base(orgIdOrName, "boards")
		{
			this.AddFilter(filter);
		}
	}
}
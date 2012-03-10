namespace TrelloNet.Internal
{
	internal class BoardsForOrganizationRequest : OrganizationsRequest
	{
		public BoardsForOrganizationRequest(IOrganizationId organization, BoardFilter filter)
			: base(organization, "boards")
		{
			this.AddFilter(filter);
		}
	}
}
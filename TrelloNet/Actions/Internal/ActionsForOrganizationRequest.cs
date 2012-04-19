namespace TrelloNet.Internal
{
	internal class ActionsForOrganizationRequest : OrganizationsRequest
	{
		public ActionsForOrganizationRequest(IOrganizationId organization, ISince since, Paging paging)
			: base(organization, "actions")
		{
			this.AddSince(since);
			this.AddPaging(paging);
		}
	}
}
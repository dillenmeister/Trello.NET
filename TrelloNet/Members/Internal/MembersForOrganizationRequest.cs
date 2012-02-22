namespace TrelloNet.Internal
{
	internal class MembersForOrganizationRequest : OrganizationsRequest
	{
		public MembersForOrganizationRequest(IOrganizationId orgIdOrName, MemberFilter filter)
			: base(orgIdOrName, "members")
		{
			this.AddFilter(filter);
		}
	}
}
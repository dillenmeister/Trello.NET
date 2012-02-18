namespace TrelloNet.Internal
{
	internal class OrganizationMembersRequest : OrganizationRequest
	{
		public OrganizationMembersRequest(IOrganizationId orgIdOrName, MemberFilter filter)
			: base(orgIdOrName, "members")
		{
			this.AddFilter(filter);
		}
	}
}
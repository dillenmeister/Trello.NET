namespace TrelloNet.Internal.Requests
{
	internal class OrganizationMembersRequest : OrganizationRequest
	{
		public OrganizationMembersRequest(string orgIdOrName, MemberFilter filter)
			: base(orgIdOrName, "members")
		{
			this.AddFilter(filter);
		}
	}
}
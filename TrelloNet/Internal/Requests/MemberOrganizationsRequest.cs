namespace TrelloNet.Internal.Requests
{
	internal class MemberOrganizationsRequest : MemberRequest
	{
		public MemberOrganizationsRequest(string memberIdOrUsername, OrganizationFilter filter)
			: base(memberIdOrUsername, "organizations")
		{
			this.AddFilter(filter);
		}
	}
}
namespace TrelloNet.Internal.Requests
{
	internal class MemberOrganizationsRequest : MemberRequest
	{
		public MemberOrganizationsRequest(IMemberId member, OrganizationFilter filter)
			: base(member, "organizations")
		{
			this.AddFilter(filter);
		}
	}
}
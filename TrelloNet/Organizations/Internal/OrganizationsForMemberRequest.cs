namespace TrelloNet.Internal
{
	internal class OrganizationsForMemberRequest : MembersRequest
	{
		public OrganizationsForMemberRequest(IMemberId member, OrganizationFilter filter)
			: base(member, "organizations")
		{
			this.AddFilter(filter);
		}
	}
}
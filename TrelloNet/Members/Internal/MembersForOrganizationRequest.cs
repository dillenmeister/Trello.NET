namespace TrelloNet.Internal
{
	internal class MembersForOrganizationRequest : OrganizationsRequest
	{
		public MembersForOrganizationRequest(IOrganizationId organization, MemberFilter filter)
			: base(organization, "members")
		{
			this.AddFilter(filter);
			AddParameter("fields", "fullName,username,bio,url,avatarHash");
		}
	}
}
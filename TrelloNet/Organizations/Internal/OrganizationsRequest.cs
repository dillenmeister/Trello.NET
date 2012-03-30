using RestSharp;

namespace TrelloNet.Internal
{
	internal class OrganizationsRequest : RestRequest
	{
		public OrganizationsRequest(IOrganizationId organization, string resource = "")
			: base("organizations/{orgIdOrName}/" + resource)
		{
			Guard.NotNull(organization, "organization");
			AddParameter("orgIdOrName", organization.GetOrganizationId(), ParameterType.UrlSegment);

			// Bug in Trello API: We have to ask for both desc and description.
			AddParameter("fields", "name,displayName,url,desc,description");
		}

		public OrganizationsRequest(string orgIdOrName, string resource = "")
			:this(new OrganizationId(orgIdOrName), resource)
		{			
		}
	}
}
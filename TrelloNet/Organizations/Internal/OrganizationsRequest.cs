using RestSharp;

namespace TrelloNet.Internal
{
	internal class OrganizationsRequest : RestRequest
	{
		public OrganizationsRequest(IOrganizationId orgIdOrName, string resource = "")
			: base("organizations/{orgIdOrName}/" + resource)
		{
			AddParameter("orgIdOrName", orgIdOrName.GetOrganizationId(), ParameterType.UrlSegment);
		}

		public OrganizationsRequest(string orgIdOrName, string resource = "")
			:this(new OrganizationId(orgIdOrName), resource)
		{			
		}
	}
}
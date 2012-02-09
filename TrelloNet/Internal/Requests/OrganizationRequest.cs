using RestSharp;

namespace TrelloNet.Internal.Requests
{
	internal class OrganizationRequest : RestRequest
	{
		public OrganizationRequest(IOrganizationId orgIdOrName, string resource = "")
			: base("organizations/{orgIdOrName}/" + resource)
		{
			AddParameter("orgIdOrName", orgIdOrName.GetOrganizationId(), ParameterType.UrlSegment);
		}

		public OrganizationRequest(string orgIdOrName, string resource = "")
			:this(new OrganizationId(orgIdOrName), resource)
		{			
		}
	}
}
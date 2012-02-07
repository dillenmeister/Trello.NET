using RestSharp;

namespace TrelloNet.Internal
{
	internal class OrganizationRequest : RestRequest
	{
		public OrganizationRequest(string orgIdOrName, string resource = "")
			: base("organizations/{orgIdOrName}/" + resource)
		{
			AddParameter("orgIdOrName", orgIdOrName, ParameterType.UrlSegment);
		}
	}
}
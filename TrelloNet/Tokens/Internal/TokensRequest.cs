using RestSharp;

namespace TrelloNet.Internal
{
	internal class TokensRequest : RestRequest
	{
		public TokensRequest(string token, string resource = "")
			: base("tokens/{token}/" + resource)
		{
			Guard.NotNullOrEmpty(token, "token");
			AddParameter("token", token, ParameterType.UrlSegment);
		}
	}
}
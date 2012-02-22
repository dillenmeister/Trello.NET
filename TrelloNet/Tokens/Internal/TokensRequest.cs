using RestSharp;

namespace TrelloNet.Internal
{
	internal class TokensRequest : RestRequest
	{
		public TokensRequest(string token, string resource = "")
			: base("tokens/{token}/" + resource)
		{
			AddParameter("token", token, ParameterType.UrlSegment);
		}
	}
}
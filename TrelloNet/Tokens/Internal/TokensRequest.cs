using RestSharp;

namespace TrelloNet.Tokens.Internal
{
	internal class TokensRequest : RestRequest
	{
		public TokensRequest(string token)
			: base("tokens/{token}")
		{
			AddParameter("token", token, ParameterType.UrlSegment);
		}
	}
}
using RestSharp;

namespace TrelloNet.Tokens.Internal
{
	internal class TokenRequest : RestRequest
	{
		public TokenRequest(string token)
			: base("tokens/{token}")
		{
			AddParameter("token", token, ParameterType.UrlSegment);
		}
	}
}
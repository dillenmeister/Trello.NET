namespace TrelloNet.Internal
{
	internal class Tokens : ITokens
	{
		private readonly TrelloRestClient _restClient;

		public Tokens(TrelloRestClient restClient)
		{
			_restClient = restClient;
		}

		public Token WithToken(string token)
		{
			Guard.NotNullOrEmpty(token, "token");
			return _restClient.Request<Token>(new TokensRequest(token));
		}
	}
}
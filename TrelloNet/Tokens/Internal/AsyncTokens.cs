using System.Threading.Tasks;

namespace TrelloNet.Internal
{
	internal class AsyncTokens : IAsyncTokens
	{
		private readonly TrelloRestClient _restClient;

		public AsyncTokens(TrelloRestClient restClient)
		{
			_restClient = restClient;
		}

		public Task<Token> WithToken(string token)
		{
			return _restClient.RequestAsync<Token>(new TokensRequest(token));
		}
	}
}
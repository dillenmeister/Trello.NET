using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrelloNet.Internal
{
	internal class AsyncTrello : IAsyncTrello
	{
		private readonly TrelloRestClient _restClient;

		internal AsyncTrello(TrelloRestClient restClient)
		{
			_restClient = restClient;

			Members = new AsyncMembers(_restClient);
			Boards = new AsyncBoards(_restClient);
			Lists = new AsyncLists(_restClient);
			Cards = new AsyncCards(_restClient);
			Checklists = new AsyncChecklists(_restClient);
			Organizations = new AsyncOrganizations(_restClient);
			Notifications = new AsyncNotifications(_restClient);
			Tokens = new AsyncTokens(_restClient);
			Actions = new AsyncActions(_restClient);
		    Advanced = new AsyncAdvanced(_restClient);
		}

		public IAsyncMembers Members { get; private set; }
		public IAsyncBoards Boards { get; private set; }
		public IAsyncLists Lists { get; private set; }
		public IAsyncCards Cards { get; private set; }
		public IAsyncChecklists Checklists { get; private set; }
		public IAsyncOrganizations Organizations { get; private set; }
		public IAsyncNotifications Notifications { get; private set; }
		public IAsyncTokens Tokens { get; private set; }
		public IAsyncActions Actions { get; private set; }
	    public IAsyncAdvanced Advanced { get; private set; }

	    public Task<SearchResults> Search(string query, int limit = 10, SearchFilter filter = null, IEnumerable<ModelType> modelTypes = null, DateTime? since = null, bool partial = false)
		{
			return _restClient.RequestAsync<SearchResults>(new SearchRequest(query, limit, filter, modelTypes, since, partial));
		}
	}
}
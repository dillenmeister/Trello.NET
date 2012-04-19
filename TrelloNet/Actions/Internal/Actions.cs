using System.Collections.Generic;
using RestSharp;

namespace TrelloNet.Internal
{
	internal class Actions : IActions
	{
		private readonly TrelloRestClient _restClient;

		public Actions(TrelloRestClient restClient)
		{
			_restClient = restClient;
		}

		public Action WithId(string actionId)
		{
			return _restClient.Request<Action>(new ActionsRequest(actionId));
		}

		public IEnumerable<Action> ForBoard(IBoardId board, ISince since = null, Paging paging = null)
		{
			return _restClient.Request<List<Action>>(new ActionsForBoardRequest(board, since, paging));
		}

		public IEnumerable<Action> ForCard(ICardId card, ISince since = null, Paging paging = null)
		{
			return _restClient.Request<List<Action>>(new ActionsForCardRequest(card, since, paging));
		}

		public IEnumerable<Action> ForList(IListId list, ISince since = null, Paging paging = null)
		{
			return _restClient.Request<List<Action>>(new ActionsForListRequest(list, since, paging));
		}
	}
}
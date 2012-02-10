using System.Collections.Generic;
using TrelloNet.Internal.Requests;

namespace TrelloNet.Internal
{
	internal class Lists : ILists
	{
		private readonly TrelloRestClient _restClient;

		public Lists(TrelloRestClient restClient)
		{
			_restClient = restClient;
		}

		public List GetById(string listId)
		{
			return _restClient.Request<List>(new ListRequest(listId));
		}

		public List GetByCard(ICardId card)
		{
			return _restClient.Request<List>(new CardListRequest(card));
		}

		public IEnumerable<List> GetByBoard(IBoardId board, ListFilter filter = ListFilter.Default)
		{
			return _restClient.Request<List<List>>(new BoardListsRequest(board, filter));
		}
	}
}
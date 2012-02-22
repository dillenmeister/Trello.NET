using System.Collections.Generic;

namespace TrelloNet.Internal
{
	internal class Lists : ILists
	{
		private readonly TrelloRestClient _restClient;

		public Lists(TrelloRestClient restClient)
		{
			_restClient = restClient;
		}

		public List WithId(string listId)
		{
			Guard.NotNullOrEmpty(listId, "listId");
			return _restClient.Request<List>(new ListsRequest(listId));
		}

		public List ForCard(ICardId card)
		{
			Guard.NotNull(card, "card");
			return _restClient.Request<List>(new ListsForCardRequest(card));
		}

		public IEnumerable<List> ForBoard(IBoardId board, ListFilter filter = ListFilter.Default)
		{
			Guard.NotNull(board, "board");
			return _restClient.Request<List<List>>(new ListsForBoardRequest(board, filter));
		}

		public List Add(NewList list)
		{
			Guard.NotNull(list, "list");
			return _restClient.Request<List>(new ListsAddRequest(list));
		}

		public void Archive(IListId list)
		{
			Guard.NotNull(list, "list");
			_restClient.Request<List>(new ListsArchiveRequest(list));
		}

		public void SendToBoard(IListId list)
		{
			Guard.NotNull(list, "list");
			_restClient.Request<List>(new ListsSendToBoardRequest(list));
		}

		public void ChangeName(IListId list, string name)
		{
			Guard.NotNull(list, "list");
			Guard.NotNullOrEmpty(name, "name");

			_restClient.Request<List>(new ListsChangeNameRequest(list, name));
		}
	}
}
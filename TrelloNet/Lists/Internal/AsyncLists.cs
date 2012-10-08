using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrelloNet.Internal
{
	internal class AsyncLists : IAsyncLists
	{
		private readonly TrelloRestClient _restClient;

		public AsyncLists(TrelloRestClient restClient)
		{
			_restClient = restClient;
		}

		public Task<List> WithId(string listId)
		{
			return _restClient.RequestAsync<List>(new ListsRequest(listId));
		}

		public Task<List> ForCard(ICardId card)
		{
			return _restClient.RequestAsync<List>(new ListsForCardRequest(card));
		}

		public Task<IEnumerable<List>> ForBoard(IBoardId board, ListFilter filter = ListFilter.Open)
		{
			return _restClient.RequestListAsync<List>(new ListsForBoardRequest(board, filter));
		}

		public Task<List> Add(NewList list)
		{
			return _restClient.RequestAsync<List>(new ListsAddRequest(list));
		}

		public Task<List> Add(string name, IBoardId board)
		{
			return Add(new NewList(name, board));
		}

		public Task Archive(IListId list)
		{
			return _restClient.RequestAsync(new ListsArchiveRequest(list));
		}

		public Task Unarchive(IListId list)
		{
			return _restClient.RequestAsync(new ListsUnarchiveRequest(list));
		}

		public Task ChangeName(IListId list, string name)
		{
			return _restClient.RequestAsync(new ListsChangeNameRequest(list, name));
		}

		public Task Update(IUpdatableList list)
		{
			return _restClient.RequestAsync(new ListsUpdateRequest(list));
		}
	}
}
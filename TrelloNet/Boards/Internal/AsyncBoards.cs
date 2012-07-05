using System.Collections.Generic;
using System.Threading.Tasks;
using TrelloNet.Internal;

namespace TrelloNet.Internal
{
	internal class AsyncBoards : IAsyncBoards
	{
		private readonly TrelloRestClient _restClient;

		public AsyncBoards(TrelloRestClient restClient)
		{
			_restClient = restClient;
		}

		public Task<Board> WithId(string boardId)
		{
			return _restClient.RequestAsync<Board>(new BoardsRequest(boardId));
		}

		public Task<Board> ForCard(ICardId card)
		{
			return _restClient.RequestAsync<Board>(new BoardsForCardRequest(card));
		}

		public Task<Board> ForChecklist(IChecklistId checklist)
		{
			return _restClient.RequestAsync<Board>(new BoardsForChecklistRequest(checklist));
		}

		public Task<Board> ForList(IListId list)
		{
			return _restClient.RequestAsync<Board>(new BoardsForListRequest(list));
		}

		public Task<IEnumerable<Board>> ForMember(IMemberId member, BoardFilter filter = BoardFilter.All)
		{
			return _restClient.RequestListAsync<Board>(new BoardsForMemberRequest(member, filter));
		}

		public Task<IEnumerable<Board>> ForMe(BoardFilter filter = BoardFilter.All)
		{
			return ForMember(new Me(), filter);
		}

		public Task<IEnumerable<Board>> ForOrganization(IOrganizationId organization, BoardFilter filter = BoardFilter.All)
		{
			return _restClient.RequestListAsync<Board>(new BoardsForOrganizationRequest(organization, filter));
		}

		public Task<Board> Add(NewBoard board)
		{
			return _restClient.RequestAsync<Board>(new BoardsAddRequest(board));
		}

		public Task<Board> Add(string name)
		{
			return Add(new NewBoard(name));
		}

		public Task Close(IBoardId board)
		{
			return _restClient.RequestAsync(new BoardsCloseRequest(board));
		}

		public Task ReOpen(IBoardId board)
		{
			return _restClient.RequestAsync(new BoardsReOpenRequest(board));
		}

		public Task ChangeName(IBoardId board, string name)
		{
			return _restClient.RequestAsync(new BoardsChangeNameRequest(board, name));
		}

		public Task ChangeDescription(IBoardId board, string description)
		{
			return _restClient.RequestAsync(new BoardsChangeDescriptionRequest(board, description));
		}

		public Task Update(IUpdatableBoard board)
		{
			return _restClient.RequestAsync(new BoardsUpdateRequest(board));
		}

		public Task<IEnumerable<Board>> Search(string query, int limit = 10, SearchFilter filter = null)
		{
			return _restClient.RequestAsync<SearchResults>(new SearchRequest(query, limit, filter, new[] { ModelType.Boards }))
				.ContinueWith<IEnumerable<Board>>(r => r.Result.Boards);			
		}
	}
}
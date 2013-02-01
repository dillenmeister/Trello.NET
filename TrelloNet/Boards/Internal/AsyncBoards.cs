using System.Collections.Generic;
using System.Threading.Tasks;

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

		public Task ChangePermissionLevel(IBoardId board, PermissionLevel permissionLevel)
		{
			return _restClient.RequestAsync(new BoardsChangePermissionLevelRequest(board, permissionLevel));
		}

		public Task Update(IUpdatableBoard board)
		{
			return _restClient.RequestAsync(new BoardsUpdateRequest(board));
		}

		public Task<IEnumerable<Board>> Search(string query, int limit = 10, SearchFilter filter = null, bool partial = false)
		{
			return _restClient.RequestAsync<SearchResults>(new SearchRequest(query, limit, filter, new[] { ModelType.Boards }, null, partial))
				.ContinueWith<IEnumerable<Board>>(r => r.Result.Boards);			
		}

		public Task MarkAsViewed(IBoardId board)
		{
			return _restClient.RequestAsync(new BoardsMarkAsViewedRequest(board));
		}

        public Task AddMember(IBoardId board, IMemberId member, BoardMemberType type = BoardMemberType.Normal)
        {
            return _restClient.RequestAsync(new BoardsAddMemberRequest(board, member, type));
        }

        public Task AddMember(IBoardId board, string email, string fullName, BoardMemberType type = BoardMemberType.Normal)
        {
            return _restClient.RequestAsync(new BoardsAddMemberRequest(board, email, fullName, type));
        }

        public Task RemoveMember(IBoardId board, IMemberId member)
        {
            return _restClient.RequestAsync(new BoardsRemoveMemberRequest(board, member));
        }

		public Task ChangeLabelName(IBoardId board, Color color, string name)
		{
			return _restClient.RequestAsync(new BoardsChangeLabelNameRequest(board, color, name));
		}
	}
}
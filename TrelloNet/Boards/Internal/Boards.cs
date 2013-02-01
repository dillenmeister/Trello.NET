using System.Collections.Generic;

namespace TrelloNet.Internal
{
	internal class Boards : IBoards
	{
		private readonly TrelloRestClient _restClient;

		internal Boards(TrelloRestClient restClient)
		{
			_restClient = restClient;
		}

		public Board WithId(string boardId)
		{
			return _restClient.Request<Board>(new BoardsWithIdRequest(boardId));
		}

		public Board ForCard(ICardId card)
		{
			return _restClient.Request<Board>(new BoardsForCardRequest(card));
		}

		public Board ForChecklist(IChecklistId checklist)
		{
			return _restClient.Request<Board>(new BoardsForChecklistRequest(checklist));
		}

		public Board ForList(IListId list)
		{
			return _restClient.Request<Board>(new BoardsForListRequest(list));
		}

		public IEnumerable<Board> ForMember(IMemberId member, BoardFilter filter = BoardFilter.All)
		{
			return _restClient.Request<List<Board>>(new BoardsForMemberRequest(member, filter));
		}

		public IEnumerable<Board> ForMe(BoardFilter filter = BoardFilter.All)
		{
			return ForMember(new Me(), filter);
		}

		public IEnumerable<Board> ForOrganization(IOrganizationId organization, BoardFilter filter = BoardFilter.All)
		{
			return _restClient.Request<List<Board>>(new BoardsForOrganizationRequest(organization, filter));
		}

		public Board Add(NewBoard board)
		{
			return _restClient.Request<Board>(new BoardsAddRequest(board));
		}

		public Board Add(string name)
		{
			return Add(new NewBoard(name));
		}

		public void Close(IBoardId board)
		{
			_restClient.Request(new BoardsCloseRequest(board));
		}

		public void ReOpen(IBoardId board)
		{
			_restClient.Request(new BoardsReOpenRequest(board));
		}

		public void ChangeName(IBoardId board, string name)
		{
			_restClient.Request(new BoardsChangeNameRequest(board, name));
		}

		public void ChangeDescription(IBoardId board, string description)
		{
			_restClient.Request(new BoardsChangeDescriptionRequest(board, description));
		}

		public void ChangePermissionLevel(IBoardId board, PermissionLevel permissionLevel)
		{
			_restClient.Request(new BoardsChangePermissionLevelRequest(board, permissionLevel));
		}

		public void Update(IUpdatableBoard board)
		{
			_restClient.Request(new BoardsUpdateRequest(board));
		}

		public IEnumerable<Board> Search(string query, int limit = 10, SearchFilter filter = null, bool partial = false)
		{
			return _restClient.Request<SearchResults>(new SearchRequest(query, limit, filter, new[] { ModelType.Boards }, null, partial)).Boards;
		}

		public void MarkAsViewed(IBoardId board)
		{
			_restClient.Request(new BoardsMarkAsViewedRequest(board));
		}

        public void AddMember(IBoardId board, IMemberId member, BoardMemberType type = BoardMemberType.Normal)
        {
            _restClient.Request(new BoardsAddMemberRequest(board, member, type));
        }

        public void AddMember(IBoardId board, string email, string fullName, BoardMemberType type = BoardMemberType.Normal)
        {
            _restClient.Request(new BoardsAddMemberRequest(board, email, fullName, type));
        }

        public void RemoveMember(IBoardId board, IMemberId member)
        {
            _restClient.Request(new BoardsRemoveMemberRequest(board, member));
        }

		public void ChangeLabelName(IBoardId board, Color color, string name)
		{
			_restClient.Request(new BoardsChangeLabelNameRequest(board, color, name));
		}
	}
}
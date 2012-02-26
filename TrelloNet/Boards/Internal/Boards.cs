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
			Guard.NotNullOrEmpty(boardId, "boardId");
			return _restClient.Request<Board>(new BoardsRequest(boardId));
		}

		public Board ForCard(ICardId card)
		{
			Guard.NotNull(card, "card");
			return _restClient.Request<Board>(new BoardsForCardRequest(card));
		}

		public Board ForChecklist(IChecklistId checklist)
		{
			Guard.NotNull(checklist, "checklist");
			return _restClient.Request<Board>(new BoardsForChecklistRequest(checklist));
		}

		public Board ForList(IListId list)
		{
			Guard.NotNull(list, "list");
			return _restClient.Request<Board>(new BoardsForListRequest(list));
		}

		public IEnumerable<Board> ForMember(IMemberId member, BoardFilter filter = BoardFilter.Default)
		{
			Guard.NotNull(member, "member");
			return _restClient.Request<List<Board>>(new BoardsForMemberRequest(member, filter));
		}

		public IEnumerable<Board> ForOrganization(IOrganizationId organization, BoardFilter filter = BoardFilter.Default)
		{
			Guard.NotNull(organization, "organization");
			return _restClient.Request<List<Board>>(new BoardsForOrganizationRequest(organization, filter));
		}

		public Board Add(NewBoard board)
		{
			Guard.NotNull(board, "board");
			return _restClient.Request<Board>(new BoardsAddRequest(board));
		}

		public Board Add(string name)
		{
			Guard.NotNullOrEmpty(name, "name");
			return Add(new NewBoard(name));
		}

		public void Close(IBoardId board)
		{
			Guard.NotNull(board, "board");
			_restClient.Request(new BoardsCloseRequest(board));
		}

		public void ReOpen(IBoardId board)
		{
			Guard.NotNull(board, "board");
			_restClient.Request(new BoardsReOpenRequest(board));
		}

		public void ChangeName(IBoardId board, string name)
		{
			Guard.NotNull(board, "board");
			Guard.NotNullOrEmpty(name, "name");

			_restClient.Request(new BoardsChangeNameRequest(board, name));
		}

		public void ChangeDescription(IBoardId board, string description)
		{
			Guard.NotNull(board, "board");
			Guard.NotNull(description, "description");
			_restClient.Request(new BoardsChangeDescriptionRequest(board, description));
		}
	}
}
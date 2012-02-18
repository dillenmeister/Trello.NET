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

		public Board GetById(string boardId)
		{
			Guard.NotNullOrEmpty(boardId, "boardId");
			return _restClient.Request<Board>(new BoardRequest(boardId));
		}

		public Board GetByCard(ICardId card)
		{
			Guard.NotNull(card, "card");
			return _restClient.Request<Board>(new CardBoardRequest(card));
		}

		public Board GetByChecklist(IChecklistId checklist)
		{
			Guard.NotNull(checklist, "checklist");
			return _restClient.Request<Board>(new ChecklistBoardRequest(checklist));
		}

		public Board GetByList(IListId list)
		{
			Guard.NotNull(list, "list");
			return _restClient.Request<Board>(new ListBoardRequest(list));
		}

		public IEnumerable<Board> GetByMember(IMemberId member, BoardFilter filter = BoardFilter.Default)
		{
			Guard.NotNull(member, "member");
			return _restClient.Request<List<Board>>(new MemberBoardsRequest(member, filter));
		}

		public IEnumerable<Board> GetByOrganization(IOrganizationId organization, BoardFilter filter = BoardFilter.Default)
		{
			Guard.NotNull(organization, "organization");
			return _restClient.Request<List<Board>>(new OrganizationBoardsRequest(organization, filter));
		}
	}
}
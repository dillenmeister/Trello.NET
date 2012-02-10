using System;
using System.Collections.Generic;
using TrelloNet.Internal.Requests;

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
			return _restClient.Request<Board>(new BoardRequest(boardId));
		}

		public Board GetByCard(ICardId card)
		{
			return _restClient.Request<Board>(new CardBoardRequest(card));
		}

		public Board GetByChecklist(IChecklistId checklist)
		{
			return _restClient.Request<Board>(new ChecklistBoardRequest(checklist));
		}

		public Board GetByList(IListId list)
		{
			return _restClient.Request<Board>(new ListBoardRequest(list));
		}

		public IEnumerable<Board> GetByMember(IMemberId member, BoardFilter filter = BoardFilter.Default)
		{
			return _restClient.Request<List<Board>>(new MemberBoardsRequest(member, filter));
		}

		public IEnumerable<Board> GetByOrganization(IOrganizationId organization, BoardFilter filter = BoardFilter.Default)
		{
			return _restClient.Request<List<Board>>(new OrganizationBoardsRequest(organization, filter));
		}
	}
}
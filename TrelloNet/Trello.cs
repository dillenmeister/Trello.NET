using System;
using System.Collections.Generic;
using TrelloNet.Internal;
using TrelloNet.Internal.Requests;

namespace TrelloNet
{
	public class Trello : ITrello
	{
		private readonly TrelloRestClient _restClient;

		public Trello(string key)
		{
			_restClient = new TrelloRestClient(key);
		}

		public void Authenticate(string token)
		{
			_restClient.Authenticate(token);
		}

		public Uri GetAuthenticationUrl(string applicationName)
		{
			return _restClient.GetAuthenticationlUrl(applicationName, AccessMode.ReadOnly);
		}

		public Member Member(string memberIdOrUsername)
		{
			var request = new MemberRequest(memberIdOrUsername);
			return _restClient.Request<Member>(request);
		}

		public Member Member(IMemberId member)
		{
			return Member(member.GetMemberId());
		}

		public IEnumerable<Member> Members(IBoardId board, MemberFilter filter = MemberFilter.All)
		{
			var request = new BoardMembersRequest(board.GetBoardId(), filter);
			return _restClient.Request<List<Member>>(request);
		}

		public IEnumerable<Member> Members(ICardId card)
		{
			var request = new CardMembersRequest(card.GetCardId());
			return _restClient.Request<List<Member>>(request);
		}

		public IEnumerable<Member> Members(IOrganizationId organization, MemberFilter filter = MemberFilter.All)
		{
			var request = new OrganizationMembersRequest(organization.GetOrganizationId(), filter);
			return _restClient.Request<List<Member>>(request);
		}

		public IEnumerable<Board> Boards(IMemberId member, BoardFilter filter = BoardFilter.All)
		{
			var request = new MemberBoardsRequest(member.GetMemberId(), filter);
			return _restClient.Request<List<Board>>(request);
		}

		public IEnumerable<Board> Boards(IOrganizationId organization, BoardFilter filter = BoardFilter.All)
		{
			var request = new OrganizationBoardsRequest(organization.GetOrganizationId(), filter);
			return _restClient.Request<List<Board>>(request);
		}

		public Board Board(string boardId)
		{
			var request = new BoardRequest(boardId);
			return _restClient.Request<Board>(request);
		}

		public Board Board(ICardId card)
		{
			var request = new CardBoardRequest(card.GetCardId());
			return _restClient.Request<Board>(request);
		}

		public Board Board(IChecklistId checklist)
		{
			var request = new ChecklistBoardRequest(checklist.GetChecklistId());
			return _restClient.Request<Board>(request);
		}

		public Board Board(IListId list)
		{
			var request = new ListBoardRequest(list.GetListId());
			return _restClient.Request<Board>(request);
		}

		public List List(string listId)
		{
			var request = new ListRequest(listId);
			return _restClient.Request<List>(request);
		}

		public List List(ICardId card)
		{
			var request = new CardListRequest(card.GetCardId());
			return _restClient.Request<List>(request);
		}

		public IEnumerable<List> Lists(IBoardId board, ListFilter filter = ListFilter.None)
		{
			var request = new BoardListsRequest(board.GetBoardId(), filter);
			return _restClient.Request<List<List>>(request);
		}

		public IEnumerable<Card> Cards(IBoardId board, CardFilter filter = CardFilter.Open)
		{
			var request = new BoardCardsRequest(board.GetBoardId(), filter);
			return _restClient.Request<List<Card>>(request);
		}

		public IEnumerable<Card> Cards(IListId list, CardFilter filter = CardFilter.Open)
		{
			var request = new ListCardsRequest(list.GetListId(), filter);
			return _restClient.Request<List<Card>>(request);
		}

		public IEnumerable<Card> Cards(IMemberId member, CardFilter filter = CardFilter.Open)
		{
			var request = new MemberCardsRequest(member.GetMemberId(), filter);
			return _restClient.Request<List<Card>>(request);
		}

		public IEnumerable<Card> Cards(IChecklistId checklist, CardFilter filter = CardFilter.Open)
		{
			var request = new ChecklistCardsRequest(checklist.GetChecklistId(), filter);
			return _restClient.Request<List<Card>>(request);
		}

		public Card Card(string cardId)
		{
			var request = new CardRequest(cardId);
			return _restClient.Request<Card>(request);
		}

		public IEnumerable<Checklist> Checklists(IBoardId board)
		{
			var request = new BoardChecklistsRequest(board.GetBoardId());
			return _restClient.Request<List<Checklist>>(request);
		}

		public IEnumerable<Checklist> Checklists(ICardId card)
		{
			var request = new CardChecklistsRequest(card.GetCardId());
			return _restClient.Request<List<Checklist>>(request);
		}

		public Checklist Checklist(string checkListId)
		{
			var request = new ChecklistRequest(checkListId);
			return _restClient.Request<Checklist>(request);
		}

		public Organization Organization(string orgIdOrName)
		{
			var request = new OrganizationRequest(orgIdOrName);
			return _restClient.Request<Organization>(request);
		}

		public Organization Organization(IBoardId board)
		{
			var request = new BoardOrganizationRequest(board.GetBoardId());
			return _restClient.Request<Organization>(request);
		}

		public IEnumerable<Organization> Organizations(IMemberId member, OrganizationFilter filter = OrganizationFilter.All)
		{
			var request = new MemberOrganizationsRequest(member.GetMemberId(), filter);
			return _restClient.Request<List<Organization>>(request);
		}
	}
}
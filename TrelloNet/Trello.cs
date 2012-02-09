using System;
using System.Collections.Generic;
using RestSharp;
using TrelloNet.Internal;

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
			var request = new BoardRequest(board, "members");
			request.AddFilter(filter);
			return _restClient.Request<List<Member>>(request);
		}

		public IEnumerable<Member> Members(ICardId card)
		{
			var request = new CardRequest(card.GetCardId(), "members");
			return _restClient.Request<List<Member>>(request);		
		}

		public IEnumerable<Member> Members(IOrganizationId organization, MemberFilter filter = MemberFilter.All)
		{
			var request = new OrganizationRequest(organization.GetOrganizationId(), "members");
			request.AddFilter(filter);
			return _restClient.Request<List<Member>>(request);
		}

		public IEnumerable<Board> Boards(IMemberId member, BoardFilter filter = BoardFilter.All)
		{
			var request = new MemberRequest(member.GetMemberId(), "boards");
			request.AddFilter(filter);
			return _restClient.Request<List<Board>>(request);
		}

		public IEnumerable<Board> Boards(IOrganizationId organization, BoardFilter filter = BoardFilter.All)
		{
			var request = new OrganizationRequest(organization.GetOrganizationId(), "boards");
			request.AddFilter(filter);
			return _restClient.Request<List<Board>>(request);
		}

		public Board Board(string boardId)
		{
			var request = new BoardRequest(new BoardId(boardId));
			return _restClient.Request<Board>(request);
		}

		public Board Board(ICardId card)
		{
			var request = new CardRequest(card.GetCardId(), "board");
			return _restClient.Request<Board>(request);
		}

		public Board Board(IChecklistId checklist)
		{
			var request = new ChecklistRequest(checklist.GetChecklistId(), "board");
			return _restClient.Request<Board>(request);
		}

		public Board Board(IListId list)
		{
			var request = new ListRequest(list.GetListId(), "board");
			return _restClient.Request<Board>(request);
		}

		public List List(string listId)
		{
			var request = new ListRequest(listId);
			return _restClient.Request<List>(request);
		}

		public List List(ICardId card)
		{
			var request = new CardRequest(card.GetCardId(), "list");
			return _restClient.Request<List>(request);
		}

		public IEnumerable<List> Lists(IBoardId board, ListFilter filter = ListFilter.None)
		{
			var request = new BoardRequest(board, "lists");
			if (filter != ListFilter.None)
				request.AddParameter("filter", filter.ToTrelloString(), ParameterType.GetOrPost);
			return _restClient.Request<List<List>>(request);
		}

		public IEnumerable<Card> Cards(IBoardId board, CardFilter filter = CardFilter.Open)
		{
			var request = new BoardRequest(board, "cards");
			request.AddParameter("labels", "true", ParameterType.GetOrPost);
			request.AddFilter(filter);
			return _restClient.Request<List<Card>>(request);
		}

		public IEnumerable<Card> Cards(IListId list, CardFilter filter = CardFilter.Open)
		{
			var request = new ListRequest(list.GetListId(), "cards");
			request.AddParameter("labels", "true", ParameterType.GetOrPost);
			request.AddFilter(filter);
			return _restClient.Request<List<Card>>(request);
		}

		public IEnumerable<Card> Cards(IMemberId member, CardFilter filter = CardFilter.Open)
		{
			var request = new MemberRequest(member.GetMemberId(), "cards");
			request.AddParameter("labels", "true", ParameterType.GetOrPost);
			request.AddFilter(filter);
			return _restClient.Request<List<Card>>(request);
		}

		public IEnumerable<Card> Cards(IChecklistId checklist, CardFilter filter = CardFilter.Open)
		{
			var request = new ChecklistRequest(checklist.GetChecklistId(), "cards");
			request.AddParameter("labels", "true", ParameterType.GetOrPost);
			request.AddFilter(filter);
			return _restClient.Request<List<Card>>(request);
		}

		public Card Card(string cardId)
		{
			var request = new CardRequest(cardId);
			return _restClient.Request<Card>(request);
		}

		public IEnumerable<Checklist> Checklists(IBoardId board)
		{
			var request = new BoardRequest(board, "checklists");
			return _restClient.Request<List<Checklist>>(request);
		}

		public IEnumerable<Checklist> Checklists(ICardId card)
		{
			var request = new CardRequest(card.GetCardId(), "checklists");
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
			var request = new BoardRequest(board, "organization");
			return _restClient.Request<Organization>(request);			
		}

		public IEnumerable<Organization> Organizations(IMemberId member, OrganizationFilter filter = OrganizationFilter.All)
		{
			var request = new MemberRequest(member.GetMemberId(), "organizations");
			request.AddFilter(filter);
			return _restClient.Request<List<Organization>>(request);
		}
	}
}
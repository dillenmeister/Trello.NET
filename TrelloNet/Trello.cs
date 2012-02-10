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

			Members = new Members(_restClient);
			Boards = new Boards(_restClient);
			Lists = new Lists(_restClient);
			Cards = new Cards(_restClient);
		}

		public IMembers Members { get; private set; }
		public IBoards Boards { get; private set; }
		public ILists Lists { get; private set; }
		public ICards Cards { get; private set; }

		public void Authenticate(string token)
		{
			_restClient.Authenticate(token);
		}

		public Uri GetAuthenticationUrl(string applicationName)
		{
			return _restClient.GetAuthenticationlUrl(applicationName, AccessMode.ReadOnly);
		}

		public IEnumerable<Checklist> Checklists(IBoardId board)
		{
			return _restClient.Request<List<Checklist>>(new BoardChecklistsRequest(board));
		}

		public IEnumerable<Checklist> Checklists(ICardId card)
		{
			return _restClient.Request<List<Checklist>>(new CardChecklistsRequest(card));
		}

		public Checklist Checklist(string checkListId)
		{
			return _restClient.Request<Checklist>(new ChecklistRequest(checkListId));
		}

		public Organization Organization(string orgIdOrName)
		{
			return _restClient.Request<Organization>(new OrganizationRequest(orgIdOrName));
		}

		public Organization Organization(IBoardId board)
		{
			return _restClient.Request<Organization>(new BoardOrganizationRequest(board));
		}

		public IEnumerable<Organization> Organizations(IMemberId member, OrganizationFilter filter = OrganizationFilter.All)
		{
			return _restClient.Request<List<Organization>>(new MemberOrganizationsRequest(member, filter));
		}
	}
}
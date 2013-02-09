using System;
using System.Collections.Generic;

namespace TrelloNet.Internal
{
	internal class Actions : IActions
	{
		private readonly TrelloRestClient _restClient;

		public Actions(TrelloRestClient restClient)
		{
			_restClient = restClient;
		}

		public Action WithId(string actionId)
		{
			return _restClient.Request<Action>(new ActionsRequest(actionId));
		}

		public IEnumerable<Action> ForBoard(IBoardId board, IEnumerable<ActionType> filter = null, ISince since = null, Paging paging = null)
		{
			return _restClient.Request<List<Action>>(new ActionsForBoardRequest(board, since, paging, filter));
		}

		public IEnumerable<Action> ForCard(ICardId card, IEnumerable<ActionType> filter = null, ISince since = null, Paging paging = null)
		{
			return _restClient.Request<List<Action>>(new ActionsForCardRequest(card, since, paging, filter));
		}

		public IEnumerable<Action> ForList(IListId list, IEnumerable<ActionType> filter = null, ISince since = null, Paging paging = null)
		{
			return _restClient.Request<List<Action>>(new ActionsForListRequest(list, since, paging, filter));
		}

		public IEnumerable<Action> ForMember(IMemberId member, IEnumerable<ActionType> filter = null, ISince since = null, Paging paging = null)
		{
			return _restClient.Request<List<Action>>(new ActionsForMemberRequest(member, since, paging, filter));
		}

		public IEnumerable<Action> ForMe(IEnumerable<ActionType> filter = null, ISince since = null, Paging paging = null)
		{
			return ForMember(new Me(), filter, since, paging);
		}

		public IEnumerable<Action> ForOrganization(IOrganizationId organization, IEnumerable<ActionType> filter = null, ISince since = null, Paging paging = null)
		{
			return _restClient.Request<List<Action>>(new ActionsForOrganizationRequest(organization, since, paging, filter));
		}

		public IEnumerable<Action> Search(string query, int limit = 10, SearchFilter filter = null, DateTime? since = null, bool partial = false)
		{
			return _restClient.Request<SearchResults>(new SearchRequest(query, limit, filter, new[] { ModelType.Actions }, since, partial)).Actions;
		}

        public void ChangeText(IActionId action, string newText)
        {
            _restClient.Request(new ActionsChangeTextRequest(action, newText));
        }

        public void Delete(IActionId action)
        {
            _restClient.Request(new ActionsDeleteRequest(action));
        }
    }
}
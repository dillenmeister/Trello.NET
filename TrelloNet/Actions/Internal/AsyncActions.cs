using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrelloNet.Internal
{
    internal class AsyncActions : IAsyncActions
    {
        private readonly TrelloRestClient _restClient;

        public AsyncActions(TrelloRestClient restClient)
        {
            _restClient = restClient;
        }

        public Task<Action> WithId(string actionId)
        {
            return _restClient.RequestAsync<Action>(new ActionsRequest(actionId));
        }

        public Task<IEnumerable<Action>> ForBoard(IBoardId board, IEnumerable<ActionType> filter = null, ISince since = null, Paging paging = null)
        {
            return _restClient.RequestListAsync<Action>(new ActionsForBoardRequest(board, since, paging, filter));
        }

        public Task<IEnumerable<Action>> ForCard(ICardId card, IEnumerable<ActionType> filter = null, ISince since = null, Paging paging = null)
        {
            return _restClient.RequestListAsync<Action>(new ActionsForCardRequest(card, since, paging, filter));
        }

        public Task<IEnumerable<Action>> ForList(IListId list, IEnumerable<ActionType> filter = null, ISince since = null, Paging paging = null)
        {
            return _restClient.RequestListAsync<Action>(new ActionsForListRequest(list, since, paging, filter));
        }

        public Task<IEnumerable<Action>> ForMember(IMemberId member, IEnumerable<ActionType> filter = null, ISince since = null, Paging paging = null)
        {
            return _restClient.RequestListAsync<Action>(new ActionsForMemberRequest(member, since, paging, filter));
        }

        public Task<IEnumerable<Action>> ForMe(IEnumerable<ActionType> filter = null, ISince since = null, Paging paging = null)
        {
            return ForMember(new Me(), filter, since, paging);
        }

        public Task<IEnumerable<Action>> ForOrganization(OrganizationId organization, IEnumerable<ActionType> filter = null, ISince since = null, Paging paging = null)
        {
            return _restClient.RequestListAsync<Action>(new ActionsForOrganizationRequest(organization, since, paging, filter));
        }

        public Task<IEnumerable<Action>> Search(string query, int limit = 10, SearchFilter filter = null, bool partial = false)
        {
            return _restClient.RequestAsync<SearchResults>(new SearchRequest(query, limit, filter, new[] {ModelType.Actions}, null, partial))
                .ContinueWith<IEnumerable<Action>>(r => r.Result.Actions);
        }

        public Task ChangeText(IActionId action, string newText)
        {
            return _restClient.RequestAsync(new ActionsChangeTextRequest(action, newText));
        }

        public Task Delete(IActionId action)
        {
            return _restClient.RequestAsync(new ActionsDeleteRequest(action));
        }
    }
}
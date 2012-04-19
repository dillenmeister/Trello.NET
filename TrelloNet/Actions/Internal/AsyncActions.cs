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

		public Task<IEnumerable<Action>> ForBoard(IBoardId board, ISince since = null, Paging paging = null)
		{
			return _restClient.RequestListAsync<Action>(new ActionsForBoardRequest(board, since, paging));
		}

		public Task<IEnumerable<Action>> ForCard(ICardId card, ISince since = null, Paging paging = null)
		{
			return _restClient.RequestListAsync<Action>(new ActionsForCardRequest(card, since, paging));
		}

		public Task<IEnumerable<Action>> ForList(IListId list, ISince since = null, Paging paging = null)
		{
			return _restClient.RequestListAsync<Action>(new ActionsForListRequest(list, since, paging));
		}

		public Task<IEnumerable<Action>> ForMember(IMemberId member, ISince since = null, Paging paging = null)
		{
			return _restClient.RequestListAsync<Action>(new ActionsForMemberRequest(member, since, paging));
		}

		public Task<IEnumerable<Action>> ForMe(ISince since = null, Paging paging = null)
		{
			return ForMember(new Me(), since, paging);
		}

		public Task<IEnumerable<Action>> ForOrganization(OrganizationId organization, ISince since = null, Paging paging = null)
		{
			return _restClient.RequestListAsync<Action>(new ActionsForOrganizationRequest(organization, since, paging));
		}
	}
}
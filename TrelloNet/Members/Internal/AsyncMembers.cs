using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrelloNet.Internal
{
	internal class AsyncMembers : IAsyncMembers
	{
		private readonly TrelloRestClient _restClient;

		internal AsyncMembers(TrelloRestClient restClient)
		{
			_restClient = restClient;
		}

		public Task<Member> WithId(string memberIdOrUsername)
		{
			return _restClient.RequestAsync<Member>(new MembersRequest(memberIdOrUsername));
		}

		public Task<Member> Me()
		{
			return _restClient.RequestAsync<Member>(new MembersRequest(new Me()));
		}

		public Task<IEnumerable<Member>> ForBoard(IBoardId board, MemberFilter filter = MemberFilter.All)
		{
			return _restClient.RequestListAsync<Member>(new MembersForBoardRequest(board, filter));
		}

		public Task<IEnumerable<Member>> ForCard(ICardId card)
		{
			return _restClient.RequestListAsync<Member>(new MembersForCardRequest(card));
		}

		public Task<IEnumerable<Member>> ForOrganization(IOrganizationId organization, MemberFilter filter = MemberFilter.All)
		{
			return _restClient.RequestListAsync<Member>(new MembersForOrganizationRequest(organization, filter));
		}

		public Task<Member> ForToken(string token)
		{
			return _restClient.RequestAsync<Member>(new MembersForTokenRequest(token));
		}

		public Task<IEnumerable<Member>> InvitedForBoard(IBoardId board)
		{
			return _restClient.RequestListAsync<Member>(new MembersInvitedForBoardRequest(board));
		}

		public Task<IEnumerable<Member>> Search(string query, int limit = 10, SearchFilter filter = null, bool partial = false)
		{
			return _restClient.RequestAsync<SearchResults>(new SearchRequest(query, limit, filter, new[] { ModelType.Members }, null, partial))
				.ContinueWith<IEnumerable<Member>>(r => r.Result.Members);
		}
	}
}
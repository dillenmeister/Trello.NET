using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrelloNet.Internal
{
	internal class AsyncOrganizations : IAsyncOrganizations
	{
		private readonly TrelloRestClient _restClient;

		public AsyncOrganizations(TrelloRestClient restClient)
		{
			_restClient = restClient;
		}

		public Task<Organization> WithId(string orgIdOrName)
		{
			return _restClient.RequestAsync<Organization>(new OrganizationsRequest(orgIdOrName));
		}

		public Task<Organization> ForBoard(IBoardId board)
		{
			return _restClient.RequestAsync<Organization>(new OrganizationsForBoardRequest(board));
		}

		public Task<IEnumerable<Organization>> ForMember(IMemberId member, OrganizationFilter filter = OrganizationFilter.All)
		{
			return _restClient.RequestListAsync<Organization>(new OrganizationsForMemberRequest(member, filter));
		}

		public Task<IEnumerable<Organization>> ForMe(OrganizationFilter filter = OrganizationFilter.All)
		{
			return ForMember(new Me(), filter);
		}

		public Task<IEnumerable<Organization>> Search(string query, int limit = 10, SearchFilter filter = null)
		{
			return _restClient.RequestAsync<SearchResults>(new SearchRequest(query, limit, filter, new[] { ModelType.Organizations }))
				.ContinueWith<IEnumerable<Organization>>(r => r.Result.Organizations);		
		}
	}
}
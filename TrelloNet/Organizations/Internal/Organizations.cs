using System.Collections.Generic;

namespace TrelloNet.Internal
{
	internal class Organizations : IOrganizations
	{
		private readonly TrelloRestClient _restClient;

		public Organizations(TrelloRestClient restClient)
		{
			_restClient = restClient;
		}

		public Organization WithId(string orgIdOrName)
		{
			return _restClient.Request<Organization>(new OrganizationsWithIdRequest(orgIdOrName));
		}

		public Organization ForBoard(IBoardId board)
		{
			return _restClient.Request<Organization>(new OrganizationsForBoardRequest(board));
		}

		public IEnumerable<Organization> ForMember(IMemberId member, OrganizationFilter filter = OrganizationFilter.All)
		{
			return _restClient.Request<List<Organization>>(new OrganizationsForMemberRequest(member, filter));
		}

		public IEnumerable<Organization> ForMe(OrganizationFilter filter = OrganizationFilter.All)
		{
			return ForMember(new Me(), filter);
		}

		public IEnumerable<Organization> Search(string query, int limit = 10, SearchFilter filter = null)
		{
			return _restClient.Request<SearchResults>(new SearchRequest(query, limit, filter, new[] { ModelType.Organizations })).Organizations;	
		}
	}
}
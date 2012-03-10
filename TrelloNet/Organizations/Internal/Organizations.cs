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
			return _restClient.Request<Organization>(new OrganizationsRequest(orgIdOrName));
		}

		public Organization ForBoard(IBoardId board)
		{
			return _restClient.Request<Organization>(new OrganizationsForBoardRequest(board));
		}

		public IEnumerable<Organization> ForMember(IMemberId member, OrganizationFilter filter = OrganizationFilter.Default)
		{
			return _restClient.Request<List<Organization>>(new OrganizationsForMemberRequest(member, filter));
		}

		public IEnumerable<Organization> ForMe(OrganizationFilter filter = OrganizationFilter.Default)
		{
			return ForMember(new Me(), filter);
		}
	}
}
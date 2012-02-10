using System;
using System.Collections.Generic;
using TrelloNet.Internal.Requests;

namespace TrelloNet.Internal
{
	internal class Organizations : IOrganizations
	{
		private readonly TrelloRestClient _restClient;

		public Organizations(TrelloRestClient restClient)
		{
			_restClient = restClient;
		}

		public Organization GetById(string organizationId)
		{
			return _restClient.Request<Organization>(new OrganizationRequest(organizationId));
		}

		public Organization GetByBoard(IBoardId board)
		{
			return _restClient.Request<Organization>(new BoardOrganizationRequest(board));
		}

		public IEnumerable<Organization> GetByMember(IMemberId member, OrganizationFilter filter = OrganizationFilter.Default)
		{
			return _restClient.Request<List<Organization>>(new MemberOrganizationsRequest(member, filter));
		}
	}
}
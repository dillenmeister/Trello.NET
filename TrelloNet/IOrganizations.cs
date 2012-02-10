using System.Collections.Generic;

namespace TrelloNet
{
	public interface IOrganizations
	{
		Organization GetById(string organizationId);
		Organization GetByBoard(IBoardId board);
		IEnumerable<Organization> GetByMember(IMemberId member, OrganizationFilter filter = OrganizationFilter.Default);
	}
}
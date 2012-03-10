using System.Collections.Generic;

namespace TrelloNet
{
	public interface IOrganizations
	{
		Organization WithId(string orgIdOrName);
		Organization ForBoard(IBoardId board);
		IEnumerable<Organization> ForMember(IMemberId member, OrganizationFilter filter = OrganizationFilter.Default);
		IEnumerable<Organization> ForMe(OrganizationFilter filter = OrganizationFilter.Default);
	}
}
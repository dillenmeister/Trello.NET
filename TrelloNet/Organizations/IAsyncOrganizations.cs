using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrelloNet
{
	public interface IAsyncOrganizations
	{
		Task<Organization> WithId(string orgIdOrName);
		Task<Organization> ForBoard(IBoardId board);
		Task<IEnumerable<Organization>> ForMember(IMemberId member, OrganizationFilter filter = OrganizationFilter.Default);
		Task<IEnumerable<Organization>> ForMe(OrganizationFilter filter = OrganizationFilter.Default);
	}
}
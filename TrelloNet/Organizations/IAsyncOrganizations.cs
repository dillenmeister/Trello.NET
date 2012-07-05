using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrelloNet
{
	public interface IAsyncOrganizations
	{
		/// <summary>
		/// GET /organizations/[org_id or name]
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Task<Organization> WithId(string orgIdOrName);

		/// <summary>
		/// GET /boards/[board_id]/organization
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Task<Organization> ForBoard(IBoardId board);

		/// <summary>
		/// GET /members/[member_id or username]/organizations
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Task<IEnumerable<Organization>> ForMember(IMemberId member, OrganizationFilter filter = OrganizationFilter.All);

		/// <summary>
		/// GET /members/me/organizations
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Task<IEnumerable<Organization>> ForMe(OrganizationFilter filter = OrganizationFilter.All);

		/// <summary>
		/// GET /search/		
		/// </summary>
		Task<IEnumerable<Organization>> Search(string query, int limit = 10);
	}
}
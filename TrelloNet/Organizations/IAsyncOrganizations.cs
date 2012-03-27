using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrelloNet
{
	public interface IAsyncOrganizations
	{
		/// <summary>
		/// GET /organizations/[org_id or name]
		/// </summary>
		Task<Organization> WithId(string orgIdOrName);

		/// <summary>
		/// GET /boards/[board_id]/organization
		/// </summary>
		Task<Organization> ForBoard(IBoardId board);

		/// <summary>
		/// GET /members/[member_id or username]/organizations
		/// </summary>
		Task<IEnumerable<Organization>> ForMember(IMemberId member, OrganizationFilter filter = OrganizationFilter.All);

		/// <summary>
		/// GET /members/me/organizations
		/// </summary>
		Task<IEnumerable<Organization>> ForMe(OrganizationFilter filter = OrganizationFilter.All);
	}
}
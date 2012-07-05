using System.Collections.Generic;

namespace TrelloNet
{
	public interface IOrganizations
	{
		/// <summary>
		/// GET /organizations/[org_id or name]
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Organization WithId(string orgIdOrName);

		/// <summary>
		/// GET /boards/[board_id]/organization
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Organization ForBoard(IBoardId board);

		/// <summary>
		/// GET /members/[member_id or username]/organizations
		/// <br/>
		/// Required permissions: read
		/// </summary>
		IEnumerable<Organization> ForMember(IMemberId member, OrganizationFilter filter = OrganizationFilter.All);

		/// <summary>
		/// GET /members/me/organizations
		/// <br/>
		/// Required permissions: read
		/// </summary>
		IEnumerable<Organization> ForMe(OrganizationFilter filter = OrganizationFilter.All);

		/// <summary>
		/// GET /search/		
		/// </summary>
		IEnumerable<Organization> Search(string query, int limit = 10);
	}
}
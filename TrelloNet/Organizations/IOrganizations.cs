using System.Collections.Generic;

namespace TrelloNet
{
	public interface IOrganizations
	{
		/// <summary>
		/// GET /organizations/[org_id or name]
		/// </summary>
		Organization WithId(string orgIdOrName);

		/// <summary>
		/// GET /boards/[board_id]/organization
		/// </summary>
		Organization ForBoard(IBoardId board);

		/// <summary>
		/// GET /members/[member_id or username]/organizations
		/// </summary>
		IEnumerable<Organization> ForMember(IMemberId member, OrganizationFilter filter = OrganizationFilter.Default);

		/// <summary>
		/// GET /members/me/organizations
		/// </summary>
		IEnumerable<Organization> ForMe(OrganizationFilter filter = OrganizationFilter.Default);
	}
}
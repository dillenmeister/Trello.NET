using System.Collections.Generic;

namespace TrelloNet
{
	public interface IMembers
	{
		/// <summary>
		/// GET /members/[member_id or username]
		/// </summary>
		Member WithId(string memberIdOrUsername);

		/// <summary>
		/// GET /members/me
		/// </summary>
		Member Me();

		/// <summary>
		/// GET /boards/[board_id]/members
		/// </summary>
		IEnumerable<Member> ForBoard(IBoardId board, MemberFilter filter = MemberFilter.Default);

		/// <summary>
		/// GET /cards/[card_id]/members
		/// </summary>
		IEnumerable<Member> ForCard(ICardId card);

		/// <summary>
		/// GET /organizations/[org_id or name]/members
		/// </summary>
		IEnumerable<Member> ForOrganization(IOrganizationId organization, MemberFilter filter = MemberFilter.Default);

		/// <summary>
		/// /tokens/[token]/member
		/// </summary>
		Member ForToken(string token);
	}
}
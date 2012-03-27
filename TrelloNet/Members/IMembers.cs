using System.Collections.Generic;

namespace TrelloNet
{
	public interface IMembers
	{
		/// <summary>
		/// GET /members/[member_id or username]
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Member WithId(string memberIdOrUsername);

		/// <summary>
		/// GET /members/me
		/// <br/>
		/// This call will respond as if you had supplied the username associated with the supplied token.
		/// Required permissions: read.
		/// </summary>
		Member Me();

		/// <summary>
		/// GET /boards/[board_id]/members
		/// <br/>
		/// Required permissions: read.
		/// </summary>
		IEnumerable<Member> ForBoard(IBoardId board, MemberFilter filter = MemberFilter.Default);

		/// <summary>
		/// GET /cards/[card_id]/members
		/// <br/>
		/// Required permissions: read.
		/// </summary>
		IEnumerable<Member> ForCard(ICardId card);

		/// <summary>
		/// GET /organizations/[org_id or name]/members
		/// <br/>
		/// Required permissions: read.
		/// </summary>
		IEnumerable<Member> ForOrganization(IOrganizationId organization, MemberFilter filter = MemberFilter.Default);

		/// <summary>
		/// GET /tokens/[token]/member
		/// <br/>
		/// Required permissions: read.
		/// </summary>
		Member ForToken(string token);
	}
}
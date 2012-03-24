using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrelloNet
{
	public interface IAsyncMembers
	{
		/// <summary>
		/// GET /members/[member_id or username]
		/// </summary>
		Task<Member> WithId(string memberIdOrUsername);

		/// <summary>
		/// GET /members/me
		/// </summary>
		Task<Member> Me();

		/// <summary>
		/// GET /boards/[board_id]/members
		/// </summary>
		Task<IEnumerable<Member>> ForBoard(IBoardId board, MemberFilter filter = MemberFilter.Default);

		/// <summary>
		/// GET /cards/[card_id]/members
		/// </summary>
		Task<IEnumerable<Member>> ForCard(ICardId card);

		/// <summary>
		/// GET /organizations/[org_id or name]/members
		/// </summary>
		Task<IEnumerable<Member>> ForOrganization(IOrganizationId organization, MemberFilter filter = MemberFilter.Default);

		/// <summary>
		/// /tokens/[token]/member
		/// </summary>
		Task<Member> ForToken(string token);
	}
}
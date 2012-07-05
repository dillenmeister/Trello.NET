using System.Collections.Generic;
using System.Threading.Tasks;
using TrelloNet.Internal;

namespace TrelloNet
{
	public interface IAsyncMembers
	{
		/// <summary>
		/// GET /members/[member_id or username]
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Task<Member> WithId(string memberIdOrUsername);

		/// <summary>
		/// GET /members/me
		/// <br/>
		/// This call will respond as if you had supplied the username associated with the supplied token.
		/// Required permissions: read.
		/// </summary>
		Task<Member> Me();

		/// <summary>
		/// GET /boards/[board_id]/members
		/// <br/>
		/// Required permissions: read.
		/// </summary>
		Task<IEnumerable<Member>> ForBoard(IBoardId board, MemberFilter filter = MemberFilter.All);

		/// <summary>
		/// GET /cards/[card_id]/members
		/// <br/>
		/// Required permissions: read.
		/// </summary>
		Task<IEnumerable<Member>> ForCard(ICardId card);

		/// <summary>
		/// GET /organizations/[org_id or name]/members
		/// <br/>
		/// Required permissions: read.
		/// </summary>
		Task<IEnumerable<Member>> ForOrganization(IOrganizationId organization, MemberFilter filter = MemberFilter.All);

		/// <summary>
		/// GET /tokens/[token]/member
		/// <br/>
		/// Required permissions: read.
		/// </summary>
		Task<Member> ForToken(string token);

		/// <summary>
		/// GET /boards/[board_id]/membersInvited
		/// Required permissions: read.
		/// </summary>
		Task<IEnumerable<Member>> InvitedForBoard(IBoardId board);


		/// <summary>
		/// GET /search/		
		/// </summary>
		Task<IEnumerable<Member>> Search(string query, int limit = 10, SearchFilter filter = null, bool partial = false);
	}
}
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrelloNet
{
	public interface IAsyncMembers
	{
		Task<Member> WithId(string memberIdOrUsername);
		Task<Member> Me();
		Task<IEnumerable<Member>> ForBoard(IBoardId board, MemberFilter filter = MemberFilter.Default);
		Task<IEnumerable<Member>> ForCard(ICardId card);
		Task<IEnumerable<Member>> ForOrganization(IOrganizationId organization, MemberFilter filter = MemberFilter.Default);
		Task<Member> ForToken(string token);
	}
}
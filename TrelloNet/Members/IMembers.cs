using System.Collections.Generic;

namespace TrelloNet
{
	public interface IMembers
	{
		Member WithId(string memberIdOrUsername);
		Member Me();
		IEnumerable<Member> ForBoard(IBoardId board, MemberFilter filter = MemberFilter.Default);
		IEnumerable<Member> ForCard(ICardId card);
		IEnumerable<Member> ForOrganization(IOrganizationId organization, MemberFilter filter = MemberFilter.Default);
		Member ForToken(string token);
	}
}
using System.Collections.Generic;

namespace TrelloNet
{
	public interface IMembers
	{
		Member GetById(string memberIdOrUsername);
		Member GetMe();
		IEnumerable<Member> GetByBoard(IBoardId board, MemberFilter filter = MemberFilter.Default);
		IEnumerable<Member> GetByCard(ICardId card);
		IEnumerable<Member> GetByOrganization(IOrganizationId organization, MemberFilter filter = MemberFilter.Default);
	}
}
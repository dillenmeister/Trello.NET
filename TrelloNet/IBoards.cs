using System.Collections.Generic;

namespace TrelloNet
{
	public interface IBoards
	{
		Board GetById(string boardId);
		Board GetByCard(ICardId card);
		Board GetByChecklist(IChecklistId checklist);
		Board GetByList(IListId list);
		IEnumerable<Board> GetByMember(IMemberId member, BoardFilter filter = BoardFilter.Default);
		IEnumerable<Board> GetByOrganization(IOrganizationId organization, BoardFilter filter = BoardFilter.Default);
	}
}
using System.Collections.Generic;

namespace TrelloNet
{
	public interface IBoards
	{
		Board WithId(string boardId);
		Board ForCard(ICardId card);
		Board ForChecklist(IChecklistId checklist);
		Board ForList(IListId list);
		IEnumerable<Board> ForMember(IMemberId member, BoardFilter filter = BoardFilter.Default);
		IEnumerable<Board> ForOrganization(IOrganizationId organization, BoardFilter filter = BoardFilter.Default);
	}
}
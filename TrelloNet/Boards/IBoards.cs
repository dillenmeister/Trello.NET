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
		IEnumerable<Board> ForMe(BoardFilter filter = BoardFilter.Default);
		IEnumerable<Board> ForOrganization(IOrganizationId organization, BoardFilter filter = BoardFilter.Default);
		Board Add(NewBoard board);
		Board Add(string name);
		void Close(IBoardId board);
		void ReOpen(IBoardId board);
		void ChangeName(IBoardId board, string name);
		void ChangeDescription(IBoardId board, string description);
	}
}
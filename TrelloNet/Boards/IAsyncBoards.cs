using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrelloNet
{
	public interface IAsyncBoards
	{
		Task<Board> WithId(string boardId);
		Task<Board> ForCard(ICardId card);
		Task<Board> ForChecklist(IChecklistId checklist);
		Task<Board> ForList(IListId list);
		Task<IEnumerable<Board>> ForMember(IMemberId member, BoardFilter filter = BoardFilter.Default);
		Task<IEnumerable<Board>> ForMe(BoardFilter filter = BoardFilter.Default);
		Task<IEnumerable<Board>> ForOrganization(IOrganizationId organization, BoardFilter filter = BoardFilter.Default);
		Task<Board> Add(NewBoard board);
		Task<Board> Add(string name);
		Task Close(IBoardId board);
		Task ReOpen(IBoardId board);
		Task ChangeName(IBoardId board, string name);
		Task ChangeDescription(IBoardId board, string description);
	}
}
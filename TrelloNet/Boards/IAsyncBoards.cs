using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrelloNet
{
	public interface IAsyncBoards
	{
		/// <summary>
		/// GET /boards/[board_id]
		/// </summary>	
		Task<Board> WithId(string boardId);

		/// <summary>
		/// GET /cards/[card_id]/board
		/// </summary>
		Task<Board> ForCard(ICardId card);

		/// <summary>
		/// GET /checklists/[checklist_id]/board
		/// </summary>
		Task<Board> ForChecklist(IChecklistId checklist);

		/// <summary>
		/// GET /lists/[list_id]/board
		/// </summary>
		Task<Board> ForList(IListId list);

		/// <summary>
		/// GET /members/[member_id or username]/boards
		/// </summary>
		Task<IEnumerable<Board>> ForMember(IMemberId member, BoardFilter filter = BoardFilter.All);

		/// <summary>
		/// GET /members/me/boards
		/// </summary>
		Task<IEnumerable<Board>> ForMe(BoardFilter filter = BoardFilter.All);

		/// <summary>
		/// GET /organizations/[org_id or name]/boards
		/// </summary>
		Task<IEnumerable<Board>> ForOrganization(IOrganizationId organization, BoardFilter filter = BoardFilter.All);

		/// <summary>
		/// POST /boards
		/// </summary>
		Task<Board> Add(NewBoard board);

		/// <summary>
		/// POST /boards
		/// </summary>
		Task<Board> Add(string name);

		/// <summary>
		/// PUT /boards/[board_id]/closed
		/// </summary>
		Task Close(IBoardId board);

		/// <summary>
		/// PUT /boards/[board_id]/closed
		/// </summary>
		Task ReOpen(IBoardId board);

		/// <summary>
		/// PUT /boards/[board_id]/name
		/// </summary>
		Task ChangeName(IBoardId board, string name);

		/// <summary>
		/// PUT /boards/[board_id]/desc
		/// </summary>
		Task ChangeDescription(IBoardId board, string description);
	}
}
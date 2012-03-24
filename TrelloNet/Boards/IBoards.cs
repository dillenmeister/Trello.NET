using System.Collections.Generic;

namespace TrelloNet
{
	public interface IBoards
	{
		/// <summary>
		/// GET /boards/[board_id]
		/// </summary>	
		Board WithId(string boardId);

		/// <summary>
		/// GET /cards/[card_id]/board
		/// </summary>
		Board ForCard(ICardId card);

		/// <summary>
		/// GET /checklists/[checklist_id]/board
		/// </summary>
		Board ForChecklist(IChecklistId checklist);

		/// <summary>
		/// GET /lists/[list_id]/board
		/// </summary>
		Board ForList(IListId list);

		/// <summary>
		/// GET /members/[member_id or username]/boards
		/// </summary>
		IEnumerable<Board> ForMember(IMemberId member, BoardFilter filter = BoardFilter.Default);

		/// <summary>
		/// GET /members/me/boards
		/// </summary>
		IEnumerable<Board> ForMe(BoardFilter filter = BoardFilter.Default);

		/// <summary>
		/// GET /organizations/[org_id or name]/boards
		/// </summary>
		IEnumerable<Board> ForOrganization(IOrganizationId organization, BoardFilter filter = BoardFilter.Default);

		/// <summary>
		/// POST /boards
		/// </summary>
		Board Add(NewBoard board);

		/// <summary>
		/// POST /boards
		/// </summary>
		Board Add(string name);

		/// <summary>
		/// PUT /boards/[board_id]/closed
		/// </summary>
		void Close(IBoardId board);

		/// <summary>
		/// PUT /boards/[board_id]/closed
		/// </summary>
		void ReOpen(IBoardId board);

		/// <summary>
		/// PUT /boards/[board_id]/name
		/// </summary>
		void ChangeName(IBoardId board, string name);

		/// <summary>
		/// PUT /boards/[board_id]/desc
		/// </summary>
		void ChangeDescription(IBoardId board, string description);
	}
}
using System.Collections.Generic;
using TrelloNet.Internal;

namespace TrelloNet
{
	public interface IBoards
	{
		/// <summary>
		/// GET /boards/[board_id]
		/// <br/>
		/// Required permissions: read
		/// </summary>	
		Board WithId(string boardId);

		/// <summary>
		/// GET /cards/[card_id]/board
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Board ForCard(ICardId card);

		/// <summary>
		/// GET /checklists/[checklist_id]/board
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Board ForChecklist(IChecklistId checklist);

		/// <summary>
		/// GET /lists/[list_id]/board
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Board ForList(IListId list);

		/// <summary>
		/// GET /members/[member_id or username]/boards
		/// <br/>
		/// Required permissions: read
		/// </summary>
		IEnumerable<Board> ForMember(IMemberId member, BoardFilter filter = BoardFilter.All);

		/// <summary>
		/// GET /members/me/boards
		/// <br/>
		/// Required permissions: read
		/// </summary>
		IEnumerable<Board> ForMe(BoardFilter filter = BoardFilter.All);

		/// <summary>
		/// GET /organizations/[org_id or name]/boards
		/// <br/>
		/// Required permissions: read
		/// </summary>
		IEnumerable<Board> ForOrganization(IOrganizationId organization, BoardFilter filter = BoardFilter.All);

		/// <summary>
		/// POST /boards
		/// <br/>
		/// Required permissions: write, add board to organization
		/// </summary>
		Board Add(NewBoard board);

		/// <summary>
		/// POST /boards
		/// <br/>
		/// Required permissions: write, add board to organization
		/// </summary>
		/// <param name="name">A string with a length from 1 to 16384</param>
		Board Add(string name);

		/// <summary>
		/// PUT /boards/[board_id]/closed
		/// <br/>
		/// Required permissions: write
		/// </summary>
		void Close(IBoardId board);

		/// <summary>
		/// PUT /boards/[board_id]/closed
		/// <br/>
		/// Required permissions: write
		/// </summary>
		void ReOpen(IBoardId board);

		/// <summary>
		/// PUT /boards/[board_id]/name
		/// <br/>
		/// Required permissions: write
		/// </summary>
		/// <param name="name">A string with a length from 1 to 16384</param>
		void ChangeName(IBoardId board, string name);

		/// <summary>
		/// PUT /boards/[board_id]/desc
		/// <br/>
		/// Required permissions: write
		/// </summary>
		/// <param name="description">A string with a length from 0 to 16384</param>
		void ChangeDescription(IBoardId board, string description);

		/// <summary>
		/// PUT /boards/[board_id]/prefs/permissionLevel
		/// <br/>
		/// Required permissions: own, write
		/// </summary>
		void ChangePermissionLevel(IBoardId board, PermissionLevel permissionLevel);

		/// <summary>
		/// PUT /boards/[board_id]
		/// <br/>
		/// Name, Desc and Closed can be updated. Required permissions: write
		/// </summary>
		void Update(IUpdatableBoard board);

		/// <summary>
		/// GET /search/		
		/// </summary>
		IEnumerable<Board> Search(string query, int limit = 10, SearchFilter filter = null, bool partial = false);
	}
}
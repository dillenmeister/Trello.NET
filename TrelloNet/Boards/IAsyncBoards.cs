using System.Collections.Generic;
using System.Threading.Tasks;
using TrelloNet.Internal;

namespace TrelloNet
{
	public interface IAsyncBoards
	{
		/// <summary>
		/// GET /boards/[board_id]
		/// <br/>
		/// Required permissions: read
		/// </summary>	
		Task<Board> WithId(string boardId);

		/// <summary>
		/// GET /cards/[card_id]/board
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Task<Board> ForCard(ICardId card);

		/// <summary>
		/// GET /checklists/[checklist_id]/board
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Task<Board> ForChecklist(IChecklistId checklist);

		/// <summary>
		/// GET /lists/[list_id]/board
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Task<Board> ForList(IListId list);

		/// <summary>
		/// GET /members/[member_id or username]/boards
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Task<IEnumerable<Board>> ForMember(IMemberId member, BoardFilter filter = BoardFilter.All);

		/// <summary>
		/// GET /members/me/boards
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Task<IEnumerable<Board>> ForMe(BoardFilter filter = BoardFilter.All);

		/// <summary>
		/// GET /organizations/[org_id or name]/boards
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Task<IEnumerable<Board>> ForOrganization(IOrganizationId organization, BoardFilter filter = BoardFilter.All);

		/// <summary>
		/// POST /boards
		/// <br/>
		/// Required permissions: write, add board to organization
		/// </summary>
		Task<Board> Add(NewBoard board);

		/// <summary>
		/// POST /boards
		/// <br/>
		/// Required permissions: write, add board to organization
		/// </summary>
		/// <param name="name">A string with a length from 1 to 16384</param>
		Task<Board> Add(string name);

		/// <summary>
		/// PUT /boards/[board_id]/closed
		/// <br/>
		/// Required permissions: write
		/// </summary>
		Task Close(IBoardId board);

		/// <summary>
		/// PUT /boards/[board_id]/closed
		/// <br/>
		/// Required permissions: write
		/// </summary>
		Task ReOpen(IBoardId board);

		/// <summary>
		/// PUT /boards/[board_id]/name
		/// <br/>
		/// Required permissions: write
		/// </summary>
		/// <param name="name">A string with a length from 1 to 16384</param>
		Task ChangeName(IBoardId board, string name);

		/// <summary>
		/// PUT /boards/[board_id]/desc
		/// <br/>
		/// Required permissions: write
		/// </summary>
		/// <param name="description">A string with a length from 0 to 16384</param>
		Task ChangeDescription(IBoardId board, string description);

		/// <summary>
		/// PUT /boards/[board_id]/prefs/permissionLevel
		/// <br/>
		/// Required permissions: own, write
		/// </summary>
		Task ChangePermissionLevel(IBoardId board, PermissionLevel permissionLevel);

		/// <summary>
		/// PUT /boards/[board_id]
		/// <br/>
		/// Name, Desc and Closed can be updated. Required permissions: write
		/// </summary>
		Task Update(IUpdatableBoard board);

		/// <summary>
		/// GET /search/		
		/// </summary>
		Task<IEnumerable<Board>> Search(string query, int limit = 10, SearchFilter filter = null, bool partial = false);

		/// <summary>
		/// POST boards/[board_id]/markAsViewed	
		/// <br/>
		/// Required permissions: read		
		/// </summary>
		Task MarkAsViewed(IBoardId board);

        /// <summary>
        /// PUT /1/boards/[board_id]/members/[idMember]
        /// <br />
        /// Required permissions: write
        /// </summary>
        Task AddMember (IBoardId board, IMemberId member, BoardMemberType type = BoardMemberType.Normal);

        /// <summary>
        ///  PUT /1/boards/[board_id]/members
        ///  <br />
        ///  required permissions: write
        /// </summary>
        Task AddMember (IBoardId board, string email, string fullName, BoardMemberType type = BoardMemberType.Normal);

        /// <summary>
        /// DELETE /1/boards/[board_id]/members/[idMember]
        /// <br />
        /// required permissions: write
        /// </summary>
        Task RemoveMember (IBoardId board, IMemberId member);
	}
}
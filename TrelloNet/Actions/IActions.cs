using System;
using System.Collections.Generic;

namespace TrelloNet
{
	public interface IActions
	{
		/// <summary>
		/// GET /actions/[action_id]
		/// <br/>
		/// Required permissions: read
		/// </summary>	
		Action WithId(string actionId);

		/// <summary>
		/// GET /boards/[board_id]/actions
		/// <br/>
		/// Required permissions: read
		/// </summary>	
		IEnumerable<Action> ForBoard(IBoardId board, IEnumerable<ActionType> filter = null, ISince since = null, Paging paging = null);

		/// <summary>
		/// GET /cards/[card_id]/actions
		/// <br/>
		/// Required permissions: read
		/// </summary>	
		IEnumerable<Action> ForCard(ICardId card, IEnumerable<ActionType> filter = null, ISince since = null, Paging paging = null);

		/// <summary>
		/// GET /lists/[list_id]/actions
		/// <br/>
		/// Required permissions: read
		/// </summary>	
		IEnumerable<Action> ForList(IListId list, IEnumerable<ActionType> filter = null, ISince since = null, Paging paging = null);

		/// <summary>
		/// GET /members/[member_id or username]/actions
		/// <br/>
		/// Required permissions: read
		/// </summary>	
		IEnumerable<Action> ForMember(IMemberId member, IEnumerable<ActionType> filter = null, ISince since = null, Paging paging = null);

		/// <summary>
		/// GET /members/me/actions
		/// <br/>
		/// Required permissions: read
		/// </summary>	
		IEnumerable<Action> ForMe(IEnumerable<ActionType> filter = null, ISince since = null, Paging paging = null);

		/// <summary>
		/// GET /organizations/[org_id or name]/actions
		/// <br/>
		/// Required permissions: read
		/// </summary>	
		IEnumerable<Action> ForOrganization(IOrganizationId organization, IEnumerable<ActionType> filter = null, ISince since = null, Paging paging = null);

		/// <summary>
		/// GET /search/		
		/// </summary>
		IEnumerable<Action> Search(string query, int limit = 10, SearchFilter filter = null, DateTime? since = null, bool partial = false);

        /// <summary>
        /// PUT /actions/[action_id]/
        /// <br/>
        /// Required permissions: write
        /// </summary>
        /// <param name="text">A string with a length from 1 to 16384</param>
        void ChangeText(IActionId action, string newText);

        /// <summary>
        /// DELETE /actions/[action_id]/
        /// <br/>
        /// Required permissions: read
        /// </summary>
        void Delete(IActionId action);

	}
}
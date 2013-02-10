using System.Collections.Generic;
using System.Threading.Tasks;
using TrelloNet.Internal;

namespace TrelloNet
{
	public interface IAsyncActions
	{
		/// <summary>
		/// GET /actions/[action_id]
		/// <br/>
		/// Required permissions: read
		/// </summary>	
		Task<Action> WithId(string actionId);

		/// <summary>
		/// GET /boards/[board_id]/actions
		/// <br/>
		/// Required permissions: read
		/// </summary>	
		Task<IEnumerable<Action>> ForBoard(IBoardId board, IEnumerable<ActionType> filter = null, ISince since = null, Paging paging = null);

		/// <summary>
		/// GET /cards/[card_id]/actions
		/// <br/>
		/// Required permissions: read
		/// </summary>	
		Task<IEnumerable<Action>> ForCard(ICardId card, IEnumerable<ActionType> filter = null, ISince since = null, Paging paging = null);

		/// <summary>
		/// GET /lists/[list_id]/actions
		/// <br/>
		/// Required permissions: read
		/// </summary>	
		Task<IEnumerable<Action>> ForList(IListId list, IEnumerable<ActionType> filter = null, ISince since = null, Paging paging = null);

		/// <summary>
		/// GET /members/[member_id or username]/actions
		/// <br/>
		/// Required permissions: read
		/// </summary>	
		Task<IEnumerable<Action>> ForMember(IMemberId member, IEnumerable<ActionType> filter = null, ISince since = null, Paging paging = null);

		/// <summary>
		/// GET /members/me/actions
		/// <br/>
		/// Required permissions: read
		/// </summary>	
		Task<IEnumerable<Action>> ForMe(IEnumerable<ActionType> filter = null, ISince since = null, Paging paging = null);

		/// <summary>
		/// GET /1/organizations/[org_id or name]/actions
		/// <br/>
		/// Required permissions: read
		/// </summary>	
		Task<IEnumerable<Action>> ForOrganization(OrganizationId organization, IEnumerable<ActionType> filter = null, ISince since = null, Paging paging = null);

		/// <summary>
		/// GET /search/		
		/// </summary>
		Task<IEnumerable<Action>> Search(string query, int limit = 10, SearchFilter filter = null, bool partial = false);

        /// <summary>
        /// PUT /actions/[action_id]/
        /// <br/>
        /// Required permissions: write
        /// </summary>
		/// <param name="newText">A string with a length from 1 to 16384</param>
        Task ChangeText(IActionId action, string newText);

        /// <summary>
        /// DELETE /actions/[action_id]/
        /// <br/>
        /// Required permissions: read
        /// </summary>
        Task Delete(IActionId action);

	}
}
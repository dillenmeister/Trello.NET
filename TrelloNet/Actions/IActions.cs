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
		IEnumerable<Action> ForBoard(IBoardId board, ISince since = null, Paging paging = null);

		/// <summary>
		/// GET /cards/[card_id]/actions
		/// <br/>
		/// Required permissions: read
		/// </summary>	
		IEnumerable<Action> ForCard(ICardId card, ISince since = null, Paging paging = null);

		/// <summary>
		/// GET /lists/[list_id]/actions
		/// <br/>
		/// Required permissions: read
		/// </summary>	
		IEnumerable<Action> ForList(IListId list, ISince since = null, Paging paging = null);

		/// <summary>
		/// GET /members/[member_id or username]/actions
		/// <br/>
		/// Required permissions: read
		/// </summary>	
		IEnumerable<Action> ForMember(IMemberId member, ISince since = null, Paging paging = null);

		/// <summary>
		/// GET /members/me/actions
		/// <br/>
		/// Required permissions: read
		/// </summary>	
		IEnumerable<Action> ForMe(ISince since = null, Paging paging = null);

		/// <summary>
		/// GET /1/organizations/[org_id or name]/actions
		/// <br/>
		/// Required permissions: read
		/// </summary>	
		IEnumerable<Action> ForOrganization(OrganizationId organization, ISince since = null, Paging paging = null);
	}
}
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrelloNet
{
	public interface IAsyncChecklists
	{
		/// <summary>
		/// GET /checklists/[checklist_id]
		/// </summary>
		Task<Checklist> WithId(string checklistId);

		/// <summary>
		/// GET /boards/[board_id]/checklists
		/// </summary>
		Task<IEnumerable<Checklist>> ForBoard(IBoardId board);

		/// <summary>
		/// GET /cards/[card_id]/checklists
		/// </summary>
		Task<IEnumerable<Checklist>> ForCard(ICardId card);

		/// <summary>
		/// POST /checklists
		/// </summary>
		Task<Checklist> Add(string name, IBoardId board);

		/// <summary>
		/// PUT /checklists/[checklist_id]/name
		/// </summary>
		Task ChangeName(IChecklistId checklist, string name);

		/// <summary>
		/// POST /checklists/[checklist_id]/checkitems
		/// </summary>
		Task AddCheckItem(IChecklistId checklist, string name);

		/// <summary>
		/// DELETE /checklists/[checklist_id]/checkitems/[idCheckItem]
		/// </summary>
		Task RemoveCheckItem(IChecklistId checklist, string checkItemId);
	}
}
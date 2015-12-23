using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrelloNet
{
	public interface IAsyncChecklists
	{
		/// <summary>
		/// GET /checklists/[checklist_id]
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Task<Checklist> WithId(string checklistId);

		/// <summary>
		/// GET /boards/[board_id]/checklists
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Task<IEnumerable<Checklist>> ForBoard(IBoardId board);

		/// <summary>
		/// GET /cards/[card_id]/checklists
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Task<IEnumerable<Checklist>> ForCard(ICardId card);

		/// <summary>
		/// POST /checklists
		/// <br/>
		/// Required permissions: write
		/// </summary>
		/// <param name="name">A string with a length from 1 to 16384.</param>
		Task<Checklist> Add(string name, ICardId card);

		/// <summary>
		/// PUT /checklists/[checklist_id]/name
		/// <br/>
		/// Required permissions: write
		/// </summary>
		/// <param name="name">A string with a length from 1 to 16384.</param>
		Task ChangeName(IChecklistId checklist, string name);

		/// <summary>
		/// POST /checklists/[checklist_id]/checkitems
		/// <br/>
		/// Required permissions: write
		/// </summary>
		/// <param name="name">A string with a length from 1 to 16384.</param>
		Task AddCheckItem(IChecklistId checklist, string name);

		/// <summary>
		/// DELETE /checklists/[checklist_id]/checkitems/[idCheckItem]
		/// <br/>
		/// Required permissions: write
		/// </summary>
		Task RemoveCheckItem(IChecklistId checklist, string checkItemId);

		/// <summary>
		/// PUT /checklists/[checklist_id]
		/// <br/>
		/// Name can be updated. Required permissions: write
		/// </summary>
		Task Update(IUpdatableChecklist checklist);
	}
}
using System.Collections.Generic;

namespace TrelloNet
{
	public interface IChecklists
	{
		/// <summary>
		/// GET /checklists/[checklist_id]
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Checklist WithId(string checklistId);

		/// <summary>
		/// GET /boards/[board_id]/checklists
		/// <br/>
		/// Required permissions: read
		/// </summary>
		IEnumerable<Checklist> ForBoard(IBoardId board);

		/// <summary>
		/// GET /cards/[card_id]/checklists
		/// <br/>
		/// Required permissions: read
		/// </summary>
		IEnumerable<Checklist> ForCard(ICardId card);

		/// <summary>
		/// POST /checklists
		/// <br/>
		/// Required permissions: write
		/// </summary>
		/// <param name="name">A string with a length from 1 to 16384.</param>
		Checklist Add(string name, IBoardId board);

		/// <summary>
		/// PUT /checklists/[checklist_id]/name
		/// <br/>
		/// Required permissions: write
		/// </summary>
		/// <param name="name">A string with a length from 1 to 16384.</param>
		void ChangeName(IChecklistId checklist, string name);

		/// <summary>
		/// POST /checklists/[checklist_id]/checkitems
		/// <br/>
		/// Required permissions: write
		/// </summary>
		/// <param name="name">A string with a length from 1 to 16384.</param>
		void AddCheckItem(IChecklistId checklist, string name);

		/// <summary>
		/// DELETE /checklists/[checklist_id]/checkitems/[idCheckItem]
		/// <br/>
		/// Required permissions: write
		/// </summary>
		void RemoveCheckItem(IChecklistId checklist, string checkItemId);

		/// <summary>
		/// PUT /checklists/[checklist_id]
		/// <br/>
		/// Required permissions: write
		/// </summary>
		void Update(IUpdatableChecklist checklist);
	}
}
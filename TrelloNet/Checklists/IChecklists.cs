using System.Collections.Generic;

namespace TrelloNet
{
	public interface IChecklists
	{
		/// <summary>
		/// GET /checklists/[checklist_id]
		/// </summary>
		Checklist WithId(string checklistId);

		/// <summary>
		/// GET /boards/[board_id]/checklists
		/// </summary>
		IEnumerable<Checklist> ForBoard(IBoardId board);

		/// <summary>
		/// GET /cards/[card_id]/checklists
		/// </summary>
		IEnumerable<Checklist> ForCard(ICardId card);

		/// <summary>
		/// POST /checklists
		/// </summary>
		Checklist Add(string name, IBoardId board);

		/// <summary>
		/// PUT /checklists/[checklist_id]/name
		/// </summary>
		void ChangeName(IChecklistId checklist, string name);

		/// <summary>
		/// POST /checklists/[checklist_id]/checkitems
		/// </summary>
		void AddCheckItem(IChecklistId checklist, string name);

		/// <summary>
		/// DELETE /checklists/[checklist_id]/checkitems/[idCheckItem]
		/// </summary>
		void RemoveCheckItem(IChecklistId checklist, string checkItemId);
	}
}
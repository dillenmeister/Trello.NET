using System;
using System.Collections.Generic;

namespace TrelloNet
{
	public interface ICards
	{
		/// <summary>
		/// GET /cards/[card_id]
		/// </summary>
		Card WithId(string cardId);

		/// <summary>
		/// GET /boards/[board_id]/cards/[idCard]
		/// </summary>
		Card WithShortId(int shortId, IBoardId boardId);

		/// <summary>
		/// GET /boards/[board_id]/cards
		/// </summary>
		IEnumerable<Card> ForBoard(IBoardId board, CardFilter filter = CardFilter.Default);

		/// <summary>
		/// GET /lists/[list_id]/cards
		/// </summary>
		IEnumerable<Card> ForList(IListId list, CardFilter filter = CardFilter.Default);

		/// <summary>
		/// GET /members/[member_id or username]/cards
		/// </summary>
		IEnumerable<Card> ForMember(IMemberId member, CardFilter filter = CardFilter.Default);

		/// <summary>
		/// GET /members/me/cards
		/// </summary>
		IEnumerable<Card> ForMe(CardFilter filter = CardFilter.Default);

		/// <summary>
		/// GET /checklists/[checklist_id]/cards
		/// </summary>
		IEnumerable<Card> ForChecklist(IChecklistId checklist, CardFilter filter = CardFilter.Default);

		/// <summary>
		/// POST /cards
		/// </summary>
		Card Add(NewCard card);

		/// <summary>
		/// POST /cards
		/// </summary>
		Card Add(string name, IListId list);

		/// <summary>
		/// DELETE /cards/[card_id]
		/// </summary>
		void Delete(ICardId card);

		/// <summary>
		/// PUT /cards/[card_id]/closed
		/// </summary>
		void Archive(ICardId card);

		/// <summary>
		/// PUT /cards/[card_id]/closed
		/// </summary>
		void SendToBoard(ICardId card);

		/// <summary>
		/// PUT /cards/[card_id]/desc
		/// </summary>
		void ChangeDescription(ICardId card, string description);

		/// <summary>
		/// PUT /cards/[card_id]/name
		/// </summary>
		void ChangeName(ICardId card, string name);

		/// <summary>
		/// PUT /cards/[card_id]/due
		/// </summary>
		void ChangeDueDate(ICardId card, DateTime? due);

		/// <summary>
		/// PUT /cards/[card_id]/idList
		/// </summary>
		void Move(ICardId card, IListId list);

		/// <summary>
		/// POST /cards/[card_id]/labels
		/// </summary>
		void AddLabel(ICardId card, Color color);

		/// <summary>
		/// DELETE /cards/[card_id]/labels/[color]
		/// </summary>
		void RemoveLabel(ICardId card, Color color);

		/// <summary>
		/// POST /cards/[card_id]/members
		/// </summary>
		void AddMember(ICardId card, IMemberId member);

		/// <summary>
		/// DELETE /cards/[card_id]/members/[idMember]
		/// </summary>
		void RemoveMember(ICardId card, IMemberId member);

		/// <summary>
		/// POST /cards/[card_id]/actions/comment
		/// </summary>
		void AddComment(ICardId card, string comment);

		/// <summary>
		/// POST /cards/[card_id]/checklists
		/// </summary>
		void AddChecklist(ICardId card, IChecklistId checklist);

		/// <summary>
		/// DELETE /cards/[card_id]/checklists/[idChecklist]
		/// </summary>
		void RemoveChecklist(ICardId card, IChecklistId checklist);
	}
}
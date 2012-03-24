using System;
using System.Collections.Generic;

namespace TrelloNet
{
	public interface ICards
	{
		/// <summary>
		/// GET /cards/[card_id]
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Card WithId(string cardId);

		/// <summary>
		/// GET /boards/[board_id]/cards/[idCard]
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Card WithShortId(int shortId, IBoardId boardId);

		/// <summary>
		/// GET /boards/[board_id]/cards
		/// <br/>
		/// Required permissions: read
		/// </summary>
		IEnumerable<Card> ForBoard(IBoardId board, CardFilter filter = CardFilter.Default);

		/// <summary>
		/// GET /lists/[list_id]/cards
		/// <br/>
		/// Required permissions: read
		/// </summary>
		IEnumerable<Card> ForList(IListId list, CardFilter filter = CardFilter.Default);

		/// <summary>
		/// GET /members/[member_id or username]/cards
		/// <br/>
		/// Required permissions: read
		/// </summary>
		IEnumerable<Card> ForMember(IMemberId member, CardFilter filter = CardFilter.Default);

		/// <summary>
		/// GET /members/me/cards
		/// <br/>
		/// Required permissions: read
		/// </summary>
		IEnumerable<Card> ForMe(CardFilter filter = CardFilter.Default);

		/// <summary>
		/// GET /checklists/[checklist_id]/cards
		/// <br/>
		/// Required permissions: read
		/// </summary>
		IEnumerable<Card> ForChecklist(IChecklistId checklist, CardFilter filter = CardFilter.Default);

		/// <summary>
		/// POST /cards
		/// <br/>
		/// Required permissions: write
		/// </summary>
		Card Add(NewCard card);

		/// <summary>
		/// POST /cards
		/// <br/>
		/// Required permissions: write
		/// </summary>
		Card Add(string name, IListId list);

		/// <summary>
		/// DELETE /cards/[card_id]
		/// <br/>
		/// Required permissions: write
		/// </summary>
		void Delete(ICardId card);

		/// <summary>
		/// PUT /cards/[card_id]/closed
		/// <br/>
		/// Required permissions: write
		/// </summary>
		void Archive(ICardId card);

		/// <summary>
		/// PUT /cards/[card_id]/closed
		/// <br/>
		/// Required permissions: write
		/// </summary>
		void SendToBoard(ICardId card);

		/// <summary>
		/// PUT /cards/[card_id]/desc
		/// <br/>
		/// Required permissions: write
		/// </summary>
		void ChangeDescription(ICardId card, string description);

		/// <summary>
		/// PUT /cards/[card_id]/name
		/// <br/>
		/// Required permissions: write
		/// </summary>
		void ChangeName(ICardId card, string name);

		/// <summary>
		/// PUT /cards/[card_id]/due
		/// <br/>
		/// Required permissions: write
		/// </summary>
		void ChangeDueDate(ICardId card, DateTime? due);

		/// <summary>
		/// PUT /cards/[card_id]/idList
		/// <br/>
		/// Required permissions: write
		/// </summary>
		void Move(ICardId card, IListId list);

		/// <summary>
		/// POST /cards/[card_id]/labels
		/// <br/>
		/// Required permissions: write
		/// </summary>
		void AddLabel(ICardId card, Color color);

		/// <summary>
		/// DELETE /cards/[card_id]/labels/[color]
		/// <br/>
		/// Required permissions: write
		/// </summary>
		void RemoveLabel(ICardId card, Color color);

		/// <summary>
		/// POST /cards/[card_id]/members
		/// <br/>
		/// Required permissions: write
		/// </summary>
		void AddMember(ICardId card, IMemberId member);

		/// <summary>
		/// DELETE /cards/[card_id]/members/[idMember]
		/// <br/>
		/// Required permissions: write
		/// </summary>
		void RemoveMember(ICardId card, IMemberId member);

		/// <summary>
		/// POST /cards/[card_id]/actions/comment
		/// <br/>
		/// Required permissions: comments
		/// </summary>
		void AddComment(ICardId card, string comment);

		/// <summary>
		/// POST /cards/[card_id]/checklists
		/// <br/>
		/// Required permissions: write
		/// </summary>
		void AddChecklist(ICardId card, IChecklistId checklist);

		/// <summary>
		/// DELETE /cards/[card_id]/checklists/[idChecklist]
		/// <br/>
		/// Required permissions: write
		/// </summary>
		void RemoveChecklist(ICardId card, IChecklistId checklist);
	}
}
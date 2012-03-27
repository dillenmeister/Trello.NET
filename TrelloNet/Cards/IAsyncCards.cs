using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrelloNet
{
	public interface IAsyncCards
	{
		/// <summary>
		/// GET /cards/[card_id]
		/// </summary>
		Task<Card> WithId(string cardId);

		/// <summary>
		/// GET /boards/[board_id]/cards/[idCard]
		/// </summary>
		Task<Card> WithShortId(int shortId, IBoardId boardId);

		/// <summary>
		/// GET /boards/[board_id]/cards
		/// </summary>
		Task<IEnumerable<Card>> ForBoard(IBoardId board, BoardCardFilter filter = BoardCardFilter.Visible);

		/// <summary>
		/// GET /lists/[list_id]/cards
		/// </summary>
		Task<IEnumerable<Card>> ForList(IListId list, CardFilter filter = CardFilter.Open);

		/// <summary>
		/// GET /members/[member_id or username]/cards
		/// </summary>
		Task<IEnumerable<Card>> ForMember(IMemberId member, CardFilter filter = CardFilter.Open);

		/// <summary>
		/// GET /members/me/cards
		/// </summary>
		Task<IEnumerable<Card>> ForMe(CardFilter filter = CardFilter.Open);

		/// <summary>
		/// GET /checklists/[checklist_id]/cards
		/// </summary>
		Task<IEnumerable<Card>> ForChecklist(IChecklistId checklist, CardFilter filter = CardFilter.Open);

		/// <summary>
		/// POST /cards
		/// </summary>
		Task<Card> Add(NewCard card);

		/// <summary>
		/// POST /cards
		/// </summary>
		Task<Card> Add(string name, IListId list);

		/// <summary>
		/// DELETE /cards/[card_id]
		/// </summary>
		Task Delete(ICardId card);

		/// <summary>
		/// PUT /cards/[card_id]/closed
		/// </summary>
		Task Archive(ICardId card);

		/// <summary>
		/// PUT /cards/[card_id]/closed
		/// </summary>
		Task SendToBoard(ICardId card);

		/// <summary>
		/// PUT /cards/[card_id]/desc
		/// </summary>
		Task ChangeDescription(ICardId card, string description);

		/// <summary>
		/// PUT /cards/[card_id]/name
		/// </summary>
		Task ChangeName(ICardId card, string name);

		/// <summary>
		/// PUT /cards/[card_id]/due
		/// </summary>
		Task ChangeDueDate(ICardId card, DateTime? due);

		/// <summary>
		/// PUT /cards/[card_id]/idList
		/// </summary>
		Task Move(ICardId card, IListId list);

		/// <summary>
		/// POST /cards/[card_id]/labels
		/// </summary>
		Task AddLabel(ICardId card, Color color);

		/// <summary>
		/// DELETE /cards/[card_id]/labels/[color]
		/// </summary>
		Task RemoveLabel(ICardId card, Color color);

		/// <summary>
		/// POST /cards/[card_id]/members
		/// </summary>
		Task AddMember(ICardId card, IMemberId member);

		/// <summary>
		/// DELETE /cards/[card_id]/members/[idMember]
		/// </summary>
		Task RemoveMember(ICardId card, IMemberId member);

		/// <summary>
		/// POST /cards/[card_id]/actions/comment
		/// </summary>
		Task AddComment(ICardId card, string comment);

		/// <summary>
		/// POST /cards/[card_id]/checklists
		/// </summary>
		Task AddChecklist(ICardId card, IChecklistId checklist);

		/// <summary>
		/// DELETE /cards/[card_id]/checklists/[idChecklist]
		/// </summary>
		Task RemoveChecklist(ICardId card, IChecklistId checklist);
	}
}
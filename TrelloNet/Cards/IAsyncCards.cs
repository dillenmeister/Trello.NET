using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrelloNet
{
	public interface IAsyncCards
	{
		/// <summary>
		/// GET /cards/[card_id]
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Task<Card> WithId(string cardId);

		/// <summary>
		/// GET /boards/[board_id]/cards/[idCard]
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Task<Card> WithShortId(int shortId, IBoardId boardId);

		/// <summary>
		/// GET /boards/[board_id]/cards
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Task<IEnumerable<Card>> ForBoard(IBoardId board, BoardCardFilter filter = BoardCardFilter.Visible);

		/// <summary>
		/// GET /lists/[list_id]/cards
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Task<IEnumerable<Card>> ForList(IListId list, CardFilter filter = CardFilter.Open);

		/// <summary>
		/// GET /members/[member_id or username]/cards
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Task<IEnumerable<Card>> ForMember(IMemberId member, CardFilter filter = CardFilter.Open);

		/// <summary>
		/// GET /members/me/cards
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Task<IEnumerable<Card>> ForMe(CardFilter filter = CardFilter.Open);

		/// <summary>
		/// GET /checklists/[checklist_id]/cards
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Task<IEnumerable<Card>> ForChecklist(IChecklistId checklist, CardFilter filter = CardFilter.Open);

		/// <summary>
		/// POST /cards
		/// <br/>
		/// Required permissions: write
		/// </summary>
		Task<Card> Add(NewCard card);

		/// <summary>
		/// POST /cards
		/// <br/>
		/// Required permissions: write
		/// </summary>
		/// <param name="name">A string with a length from 1 to 16384</param> 
		Task<Card> Add(string name, IListId list);

		/// <summary>
		/// DELETE /cards/[card_id]
		/// <br/>
		/// Required permissions: write
		/// </summary>
		Task Delete(ICardId card);

		/// <summary>
		/// PUT /cards/[card_id]/closed
		/// <br/>
		/// Required permissions: write
		/// </summary>
		Task Archive(ICardId card);

		/// <summary>
		/// PUT /cards/[card_id]/closed
		/// <br/>
		/// Required permissions: write
		/// </summary>
		Task SendToBoard(ICardId card);

		/// <summary>
		/// PUT /cards/[card_id]/desc
		/// <br/>
		/// Required permissions: write
		/// </summary>
		/// <param name="description">A string with a length from 0 to 16384</param>
		Task ChangeDescription(ICardId card, string description);

		/// <summary>
		/// PUT /cards/[card_id]/name
		/// <br/>
		/// Required permissions: write
		/// </summary>
		/// <param name="name">A string with a length from 1 to 16384</param>
		Task ChangeName(ICardId card, string name);

		/// <summary>
		/// PUT /cards/[card_id]/due
		/// <br/>
		/// Required permissions: write
		/// </summary>
		Task ChangeDueDate(ICardId card, DateTime? due);

		/// <summary>
		/// PUT /cards/[card_id]/idList
		/// <br/>
		/// Required permissions: write
		/// </summary>
		/// <param name="list">The list the card should be moved to</param>
		Task Move(ICardId card, IListId list);

		/// <summary>
		/// POST /cards/[card_id]/labels
		/// <br/>
		/// Required permissions: write
		/// </summary>
		Task AddLabel(ICardId card, Color color);

		/// <summary>
		/// DELETE /cards/[card_id]/labels/[color]
		/// <br/>
		/// Required permissions: write
		/// </summary>
		Task RemoveLabel(ICardId card, Color color);

		/// <summary>
		/// POST /cards/[card_id]/members
		/// <br/>
		/// Required permissions: write
		/// </summary>
		/// <param name="member">The member to add to the card</param>
		Task AddMember(ICardId card, IMemberId member);

		/// <summary>
		/// DELETE /cards/[card_id]/members/[idMember]
		/// <br/>
		/// Required permissions: write
		/// </summary>
		/// <param name="member">The member to remove from the card</param>
		Task RemoveMember(ICardId card, IMemberId member);

		/// <summary>
		/// POST /cards/[card_id]/actions/comment
		/// <br/>
		/// Required permissions: comments
		/// </summary>
		/// <param name="comment">A string with a length from 1 to 16384</param>
		Task AddComment(ICardId card, string comment);

		/// <summary>
		/// POST /cards/[card_id]/checklists
		/// <br/>
		/// Required permissions: write
		/// </summary>
		/// <param name="checklist">The checklist to add to the card</param>
		Task AddChecklist(ICardId card, IChecklistId checklist);

		/// <summary>
		/// DELETE /cards/[card_id]/checklists/[idChecklist]
		/// <br/>
		/// Required permissions: write
		/// </summary>
		/// <param name="checklist">The checklist to remove from the card</param>
		Task RemoveChecklist(ICardId card, IChecklistId checklist);

		/// <summary>
		/// PUT /cards/[card_id]
		/// <br/>
		/// Name, Desc, Closed, IdList and Due can be updated. Required permissions: write
		/// </summary>
		Task Update(IUpdatableCard card);

		/// <summary>
		/// GET /search/		
		/// </summary>
		Task<IEnumerable<Card>> Search(string query, int limit = 10);
	}
}
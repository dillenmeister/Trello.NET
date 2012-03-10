using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrelloNet
{
	public interface IAsyncCards
	{
		Task<Card> WithId(string cardId);
		Task<Card> WithShortId(int shortId, IBoardId boardId);
		Task<IEnumerable<Card>> ForBoard(IBoardId board, CardFilter filter = CardFilter.Default);
		Task<IEnumerable<Card>> ForList(IListId list, CardFilter filter = CardFilter.Default);
		Task<IEnumerable<Card>> ForMember(IMemberId member, CardFilter filter = CardFilter.Default);
		Task<IEnumerable<Card>> ForMe(CardFilter filter = CardFilter.Default);
		Task<IEnumerable<Card>> ForChecklist(IChecklistId checklist, CardFilter filter = CardFilter.Default);
		Task<Card> Add(NewCard card);
		Task<Card> Add(string name, IListId list);
		Task Delete(ICardId card);
		Task Archive(ICardId card);
		Task SendToBoard(ICardId card);
		Task ChangeDescription(ICardId card, string description);
		Task ChangeName(ICardId card, string name);
		Task ChangeDueDate(ICardId card, DateTime? due);
		Task Move(ICardId card, IListId list);
		Task AddLabel(ICardId card, Color color);
		Task RemoveLabel(ICardId card, Color color);
		Task AddMember(ICardId card, IMemberId member);
		Task RemoveMember(ICardId card, IMemberId member);
		Task AddComment(ICardId card, string comment);
		Task AddChecklist(ICardId card, IChecklistId checklist);
		Task RemoveChecklist(ICardId card, IChecklistId checklist);
	}
}
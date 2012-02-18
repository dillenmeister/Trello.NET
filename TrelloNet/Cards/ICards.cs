using System.Collections.Generic;

namespace TrelloNet
{
	public interface ICards
	{
		Card WithId(string cardId);
		Card WithShortId(int shortId, IBoardId boardId);
		IEnumerable<Card> ForBoard(IBoardId board, CardFilter filter = CardFilter.Default);
		IEnumerable<Card> ForList(IListId list, CardFilter filter = CardFilter.Default);
		IEnumerable<Card> ForMember(IMemberId member, CardFilter filter = CardFilter.Default);
		IEnumerable<Card> ForChecklist(IChecklistId checklist, CardFilter filter = CardFilter.Default);
	}
}
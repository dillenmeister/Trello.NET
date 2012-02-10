using System.Collections.Generic;

namespace TrelloNet
{
	public interface ICards
	{
		Card GetById(string cardId);
		IEnumerable<Card> GetByBoard(IBoardId board, CardFilter filter = CardFilter.Default);
		IEnumerable<Card> GetByList(IListId list, CardFilter filter = CardFilter.Default);
		IEnumerable<Card> GetByMember(IMemberId member, CardFilter filter = CardFilter.Default);
		IEnumerable<Card> GetByChecklist(IChecklistId checklist, CardFilter filter = CardFilter.Default);
	}
}
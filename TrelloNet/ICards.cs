using System.Collections.Generic;

namespace TrelloNet
{
	public interface ICards
	{
		Card GetById(string cardId);
		IEnumerable<Card> GetByBoard(string boardId, CardFilter filter = CardFilter.Default);
		IEnumerable<Card> GetByList(string listId, CardFilter filter = CardFilter.Default);
		IEnumerable<Card> GetByMember(string memberId, CardFilter filter = CardFilter.Default);
		IEnumerable<Card> GetByChecklist(string checklistId, CardFilter filter = CardFilter.Default);
	}
}
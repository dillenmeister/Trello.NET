using System.Collections.Generic;

namespace TrelloNet
{
	public interface ILists
	{
		List GetById(string listId);
		List GetByCard(string cardId);
		IEnumerable<List> GetByBoard(string boardId, ListFilter filter = ListFilter.Default);
	}
}
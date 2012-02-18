using System.Collections.Generic;

namespace TrelloNet
{
	public interface ILists
	{
		List GetById(string listId);
		List GetByCard(ICardId card);
		IEnumerable<List> GetByBoard(IBoardId board, ListFilter filter = ListFilter.Default);
	}
}
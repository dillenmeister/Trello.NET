using System.Collections.Generic;

namespace TrelloNet
{
	public interface ILists
	{
		List WithId(string listId);
		List ForCard(ICardId card);
		IEnumerable<List> ForBoard(IBoardId board, ListFilter filter = ListFilter.Default);
	}
}
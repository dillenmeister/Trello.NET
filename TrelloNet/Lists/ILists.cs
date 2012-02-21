using System.Collections.Generic;

namespace TrelloNet
{
	public interface ILists
	{
		List WithId(string listId);
		List ForCard(ICardId card);
		IEnumerable<List> ForBoard(IBoardId board, ListFilter filter = ListFilter.Default);
		List Add(NewList list);
		void Archive(IListId list);
		void SendToBoard(IListId list);
		void ChangeName(IListId list, string name);
	}
}
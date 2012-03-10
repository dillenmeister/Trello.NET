using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrelloNet
{
	public interface IAsyncLists
	{
		Task<List> WithId(string listId);
		Task<List> ForCard(ICardId card);
		Task<IEnumerable<List>> ForBoard(IBoardId board, ListFilter filter = ListFilter.Default);
		Task<List> Add(NewList list);
		Task<List> Add(string name, IBoardId board);
		Task Archive(IListId list);
		Task SendToBoard(IListId list);
		Task ChangeName(IListId list, string name);
	}
}
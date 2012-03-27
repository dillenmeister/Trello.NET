using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrelloNet
{
	public interface IAsyncLists
	{
		/// <summary>
		/// GET /lists/[list_id]
		/// </summary>
		Task<List> WithId(string listId);

		/// <summary>
		/// GET /cards/[card_id]/list
		/// </summary>
		Task<List> ForCard(ICardId card);

		/// <summary>
		/// GET /boards/[board_id]/lists
		/// </summary>
		Task<IEnumerable<List>> ForBoard(IBoardId board, ListFilter filter = ListFilter.Default);

		/// <summary>
		/// POST /lists
		/// </summary>
		Task<List> Add(NewList list);

		/// <summary>
		/// POST /lists
		/// </summary>
		Task<List> Add(string name, IBoardId board);

		/// <summary>
		/// PUT /lists/[list_id]/closed
		/// </summary>
		Task Archive(IListId list);

		/// <summary>
		/// PUT /lists/[list_id]/closed
		/// </summary>
		Task SendToBoard(IListId list);

		/// <summary>
		/// PUT /lists/[list_id]/name
		/// </summary>
		Task ChangeName(IListId list, string name);
	}
}
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrelloNet
{
	public interface IAsyncLists
	{
		/// <summary>
		/// GET /lists/[list_id]
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Task<List> WithId(string listId);

		/// <summary>
		/// GET /cards/[card_id]/list
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Task<List> ForCard(ICardId card);

		/// <summary>
		/// GET /boards/[board_id]/lists
		/// <br/>
		/// Required permissions: read
		/// </summary>
		Task<IEnumerable<List>> ForBoard(IBoardId board, ListFilter filter = ListFilter.Open);

		/// <summary>
		/// POST /lists
		/// <br/>
		/// Required permissions: write
		/// </summary>
		Task<List> Add(NewList list);

		/// <summary>
		/// POST /lists
		/// <br/>
		/// Required permissions: write
		/// <param name="name">A string with a length from 1 to 16384</param> 
		/// </summary>
		Task<List> Add(string name, IBoardId board);

		/// <summary>
		/// PUT /lists/[list_id]/closed
		/// <br/>
		/// Required permissions: write
		/// </summary>
		Task Archive(IListId list);

		/// <summary>
		/// PUT /lists/[list_id]/closed
		/// <br/>
		/// Required permissions: write
		/// </summary>
		Task Unarchive(IListId list);

		/// <summary>
		/// PUT /lists/[list_id]/name
		/// <br/>
		/// Required permissions: write
		/// <param name="name">A string with a length from 1 to 16384</param> 
		/// </summary>
		Task ChangeName(IListId list, string name);

		/// <summary>
		/// PUT /lists/[list_id]
		/// <br/>
		/// Name and Closed can be updated. Required permissions: write		
		/// </summary>
		Task Update(IUpdatableList list);
	}
}
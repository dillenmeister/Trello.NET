using System.Collections.Generic;

namespace TrelloNet
{
	public interface ILists
	{
		/// <summary>
		/// GET /lists/[list_id]
		/// <br/>
		/// Required permissions: read
		/// </summary>
		List WithId(string listId);

		/// <summary>
		/// GET /cards/[card_id]/list
		/// <br/>
		/// Required permissions: read
		/// </summary>
		List ForCard(ICardId card);

		/// <summary>
		/// GET /boards/[board_id]/lists
		/// <br/>
		/// Required permissions: read
		/// </summary>
		IEnumerable<List> ForBoard(IBoardId board, ListFilter filter = ListFilter.Open);

		/// <summary>
		/// POST /lists
		/// <br/>
		/// Required permissions: write
		/// </summary>
		List Add(NewList list);

		/// <summary>
		/// POST /lists
		/// <br/>
		/// Required permissions: write
		/// <param name="name">A string with a length from 1 to 16384</param> 
		/// </summary>
		List Add(string name, IBoardId board);

		/// <summary>
		/// PUT /lists/[list_id]/closed
		/// <br/>
		/// Required permissions: write
		/// </summary>
		void Archive(IListId list);

		/// <summary>
		/// PUT /lists/[list_id]/closed
		/// <br/>
		/// Required permissions: write
		/// </summary>
		void Unarchive(IListId list);

		/// <summary>
		/// PUT /lists/[list_id]/name
		/// <br/>
		/// Required permissions: write
		/// <param name="name">A string with a length from 1 to 16384</param> 
		/// </summary>
		void ChangeName(IListId list, string name);

		/// <summary>
		/// PUT /lists/[list_id]
		/// <br/>
		/// Name and Closed can be updated. Required permissions: write		
		/// </summary>
		void Update(IUpdatableList list);

		/// <summary>
		/// PUT /lists/[list_id]/pos
		/// <br/>
		/// Required permissions: write		
		/// </summary>
		void ChangePos(IListId list, double pos);

		/// <summary>
		/// PUT /lists/[list_id]/pos
		/// <br/>
		/// Required permissions: write		
		/// </summary>
		void ChangePos(IListId list, Position pos);
	}
}
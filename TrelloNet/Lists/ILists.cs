using System.Collections.Generic;

namespace TrelloNet
{
	public interface ILists
	{
		/// <summary>
		/// GET /lists/[list_id]
		/// </summary>
		List WithId(string listId);

		/// <summary>
		/// GET /cards/[card_id]/list
		/// </summary>
		List ForCard(ICardId card);

		/// <summary>
		/// GET /boards/[board_id]/cards
		/// </summary>
		IEnumerable<List> ForBoard(IBoardId board, ListFilter filter = ListFilter.Default);

		/// <summary>
		/// POST /lists
		/// </summary>
		List Add(NewList list);

		/// <summary>
		/// POST /lists
		/// </summary>
		List Add(string name, IBoardId board);

		/// <summary>
		/// PUT /lists/[list_id]/closed
		/// </summary>
		void Archive(IListId list);

		/// <summary>
		/// PUT /lists/[list_id]/closed
		/// </summary>
		void SendToBoard(IListId list);

		/// <summary>
		/// PUT /lists/[list_id]/name
		/// </summary>
		void ChangeName(IListId list, string name);
	}
}
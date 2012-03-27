using TrelloNet.Internal;

namespace TrelloNet
{
	public class NewList
	{
		/// <summary>
		/// A string with a length from 1 to 16384 (required).
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Id of the board that the list should be added to (required).
		/// </summary>
		public IBoardId IdBoard { get; set; }

		/// <param name="name">A string with a length from 1 to 16384.</param>
		/// <param name="board">Id of the board that the list should be added to.</param>
		public NewList(string name, IBoardId board)
		{
			Guard.NotNull(board, "board");

			Name = name;
			IdBoard = board;
		}
	}
}
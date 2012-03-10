using TrelloNet.Internal;

namespace TrelloNet
{
	public class NewList
	{
		public string Name { get; set; }
		public string IdBoard { get; set; }

		public NewList(string name, string idBoard)
		{
			Guard.NotNullOrEmpty(name, "name");
			Guard.NotNullOrEmpty(idBoard, "idBoard");

			Name = name;
			IdBoard = idBoard;
		}

		public NewList(string name, IBoardId board)
		{
			Guard.NotNullOrEmpty(name, "name");
			Guard.NotNull(board, "board");

			Name = name;
			IdBoard = board.GetBoardId();
		}
	}
}
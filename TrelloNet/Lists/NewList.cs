namespace TrelloNet
{
	public class NewList
	{
		public string Name { get; set; }
		public string IdBoard { get; set; }

		public NewList(string name, string idBoard)
		{
			Name = name;
			IdBoard = idBoard;
		}

		public NewList(string name, IBoardId board)
		{
			Name = name;
			IdBoard = board.GetBoardId();
		}
	}
}
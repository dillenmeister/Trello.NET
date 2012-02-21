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
	}
}
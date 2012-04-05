namespace TrelloNet
{
	public class BoardName : IBoardId
	{
		public string Id { get; set; }
		public string Name { get; set; }

		public string GetBoardId()
		{
			return Id;
		}
	}
}
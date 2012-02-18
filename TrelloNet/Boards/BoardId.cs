namespace TrelloNet
{
	public class BoardId : IBoardId
	{
		private readonly string _id;

		public BoardId(string id)
		{
			_id = id;
		}

		public string GetBoardId()
		{
			return _id;
		}
	}
}
using TrelloNet.Internal;

namespace TrelloNet
{
	public class BoardId : IBoardId
	{
		private readonly string _id;

		public BoardId(string id)
		{
			Guard.NotNullOrEmpty(id, "id");

			_id = id;
		}

		public string Id
		{
			get { return _id; }
		}

		public string GetBoardId()
		{
			return Id;
		}		
	}
}
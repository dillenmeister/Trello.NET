using TrelloNet.Internal;

namespace TrelloNet
{
	public class BoardId : IBoardId
	{
		private readonly string _boardId;

		public BoardId(string boardId)
		{
			Guard.NotNullOrEmpty(boardId, "boardId");

			_boardId = boardId;
		}

		public string GetBoardId()
		{
			return _boardId;
		}
	}
}
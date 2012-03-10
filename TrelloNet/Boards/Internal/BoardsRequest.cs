using RestSharp;

namespace TrelloNet.Internal
{
	internal class BoardsRequest : RestRequest
	{
		public BoardsRequest(IBoardId board, string resource = "", Method method = Method.GET)
			: base("boards/{boardId}/" + resource, method)
		{
			Guard.NotNull(board, "board");
			AddParameter("boardId", board.GetBoardId(), ParameterType.UrlSegment);
		}

		public BoardsRequest(string boardId, string resource = "")
			: this(new BoardId(boardId), resource)
		{
		}
	}
}
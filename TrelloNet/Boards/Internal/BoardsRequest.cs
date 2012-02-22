using RestSharp;

namespace TrelloNet.Internal
{
	internal class BoardsRequest : RestRequest
	{
		public BoardsRequest(IBoardId boardId, string resource = "", Method method = Method.GET)
			: base("boards/{boardId}/" + resource, method)
		{
			AddParameter("boardId", boardId.GetBoardId(), ParameterType.UrlSegment);
		}

		public BoardsRequest(string boardId, string resource = "")
			: this(new BoardId(boardId), resource)
		{
		}
	}
}
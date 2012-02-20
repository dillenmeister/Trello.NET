using RestSharp;

namespace TrelloNet.Internal
{
	internal class BoardRequest : RestRequest
	{
		public BoardRequest(IBoardId boardId, string resource = "", Method method = Method.GET)
			: base("boards/{boardId}/" + resource, method)
		{
			AddParameter("boardId", boardId.GetBoardId(), ParameterType.UrlSegment);
		}

		public BoardRequest(string boardId, string resource = "")
			: this(new BoardId(boardId), resource)
		{
		}
	}
}
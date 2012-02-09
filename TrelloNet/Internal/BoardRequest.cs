using RestSharp;

namespace TrelloNet.Internal
{
	internal class BoardRequest : RestRequest
	{
		public BoardRequest(IBoardId boardId, string resource = "")
			: base("boards/{boardId}/" + resource)
		{			
			AddParameter("boardId", boardId.GetBoardId(), ParameterType.UrlSegment);
		}
	}
}
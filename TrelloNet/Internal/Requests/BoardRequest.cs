using RestSharp;

namespace TrelloNet.Internal.Requests
{
	internal class BoardRequest : RestRequest
	{
		public BoardRequest(string boardId, string resource = "")
			: base("boards/{boardId}/" + resource)
		{			
			AddParameter("boardId", boardId, ParameterType.UrlSegment);
		}
	}
}
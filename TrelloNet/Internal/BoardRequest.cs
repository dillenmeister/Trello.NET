using RestSharp;

namespace TrelloNet.Internal
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
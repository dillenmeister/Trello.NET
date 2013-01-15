using RestSharp;

namespace TrelloNet.Internal
{
	internal class BoardsMarkAsViewedRequest : BoardsRequest
	{
		public BoardsMarkAsViewedRequest(IBoardId board)
			: base(board, "markAsViewed", Method.POST)
		{
		}
	}
}
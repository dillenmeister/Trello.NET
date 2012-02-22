using RestSharp;

namespace TrelloNet.Internal
{
	internal class BoardsReOpenRequest : BoardsRequest
	{
		public BoardsReOpenRequest(IBoardId board)
			: base(board, "closed", Method.PUT)
		{
			this.AddValue("false");			
		}
	}
}
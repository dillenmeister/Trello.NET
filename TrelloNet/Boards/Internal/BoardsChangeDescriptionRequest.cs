using RestSharp;

namespace TrelloNet.Internal
{
	internal class BoardsChangeDescriptionRequest : BoardRequest
	{
		public BoardsChangeDescriptionRequest(IBoardId board, string description)
			: base(board, "desc", Method.PUT)
		{
			AddParameter("value", description);
		}
	}
}
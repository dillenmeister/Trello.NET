using RestSharp;

namespace TrelloNet.Internal
{
	internal class BoardsChangeDescriptionRequest : BoardsRequest
	{
		public BoardsChangeDescriptionRequest(IBoardId board, string description)
			: base(board, "desc", Method.PUT)
		{
			Guard.NotNull(description, "description");

			this.AddValue(description);			
		}
	}
}
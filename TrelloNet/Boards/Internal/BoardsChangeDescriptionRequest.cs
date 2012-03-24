using RestSharp;

namespace TrelloNet.Internal
{
	internal class BoardsChangeDescriptionRequest : BoardsRequest
	{
		public BoardsChangeDescriptionRequest(IBoardId board, string description)
			: base(board, "desc", Method.PUT)
		{
			Guard.LengthBetween(description, 0, 16384, "desc");

			this.AddValue(description);			
		}
	}
}
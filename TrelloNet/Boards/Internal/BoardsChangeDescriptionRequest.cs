using RestSharp;

namespace TrelloNet.Internal
{
	internal class BoardsChangeDescriptionRequest : BoardsRequest
	{
		public BoardsChangeDescriptionRequest(IBoardId board, string description)
			: base(board, "desc", Method.PUT)
		{
			Guard.OptionalTrelloString(description, "desc");

			this.AddValue(description);			
		}
	}
}
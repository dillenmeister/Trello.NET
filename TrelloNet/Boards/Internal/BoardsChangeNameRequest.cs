using RestSharp;

namespace TrelloNet.Internal
{
	internal class BoardsChangeNameRequest : BoardsRequest
	{
		public BoardsChangeNameRequest(IBoardId board, string name)
			: base(board, "name", Method.PUT)
		{
			Guard.LengthBetween(name, 1, 16384, "name");

			this.AddValue(name);			
		}
	}
}
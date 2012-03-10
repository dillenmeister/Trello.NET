using RestSharp;

namespace TrelloNet.Internal
{
	internal class BoardsChangeNameRequest : BoardsRequest
	{
		public BoardsChangeNameRequest(IBoardId board, string name)
			: base(board, "name", Method.PUT)
		{
			Guard.NotNullOrEmpty(name, "name");

			this.AddValue(name);			
		}
	}
}
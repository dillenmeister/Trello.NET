using RestSharp;

namespace TrelloNet.Internal
{
	internal class BoardsChangeNameRequest : BoardRequest
	{
		public BoardsChangeNameRequest(IBoardId board, string name)
			: base(board, "name", Method.PUT)
		{
			this.AddValue(name);			
		}
	}
}
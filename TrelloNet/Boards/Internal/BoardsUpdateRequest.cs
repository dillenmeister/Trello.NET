using RestSharp;

namespace TrelloNet.Internal
{
	internal class BoardsUpdateRequest : BoardsRequest
	{
		public BoardsUpdateRequest(IUpdatableBoard board)
			: base(board.Id, method: Method.PUT)
		{
			Guard.RequiredTrelloString(board.Name, "name");

			AddParameter("name", board.Name);
			AddParameter("closed", board.Closed.ToTrelloString());
		}
	}
}
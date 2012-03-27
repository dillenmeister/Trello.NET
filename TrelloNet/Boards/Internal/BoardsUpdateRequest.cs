using RestSharp;

namespace TrelloNet.Internal
{
	internal class BoardsUpdateRequest : BoardsRequest
	{
		public BoardsUpdateRequest(IUpdatableBoard board)
			: base(board.Id, method: Method.PUT)
		{
			Guard.RequiredTrelloString(board.Name, "name");
			Guard.OptionalTrelloString(board.Desc, "desc");

			AddParameter("name", board.Name);
			AddParameter("desc", board.Desc);
			AddParameter("closed", board.Closed.ToTrelloString());
		}
	}
}
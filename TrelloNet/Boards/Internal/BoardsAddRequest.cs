using RestSharp;

namespace TrelloNet.Internal
{
	internal class BoardsAddRequest : RestRequest
	{
		public BoardsAddRequest(NewBoard board)
			: base("boards", Method.POST)
		{
			Guard.NotNull(board, "board");
			Guard.LengthBetween(board.Name, 1, 16384, "name");

			AddParameter("name", board.Name);

			if (!string.IsNullOrEmpty(board.Desc))
			{
				Guard.LengthBetween(board.Desc, 0, 16384, "desc");
				AddParameter("desc", board.Desc);
			}

			if (!string.IsNullOrEmpty(board.IdOrganization))
				AddParameter("idOrganization", board.IdOrganization);
		}
	}
}
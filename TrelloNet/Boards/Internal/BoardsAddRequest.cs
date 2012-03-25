using RestSharp;

namespace TrelloNet.Internal
{
	internal class BoardsAddRequest : RestRequest
	{
		public BoardsAddRequest(NewBoard board)
			: base("boards", Method.POST)
		{
			Guard.NotNull(board, "board");
			Guard.RequiredTrelloString(board.Name, "name");

			AddParameter("name", board.Name);

			if (!string.IsNullOrEmpty(board.Desc))
			{
				Guard.OptionalTrelloString(board.Desc, "desc");
				AddParameter("desc", board.Desc);
			}

			if (!string.IsNullOrEmpty(board.IdOrganization))
				AddParameter("idOrganization", board.IdOrganization);
		}
	}
}
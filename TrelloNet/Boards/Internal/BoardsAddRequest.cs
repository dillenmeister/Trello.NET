using RestSharp;

namespace TrelloNet.Internal
{
	internal class BoardsAddRequest : RestRequest
	{
		public BoardsAddRequest(NewBoard board)
			: base("boards", Method.POST)
		{
			AddParameter("name", board.Name);

			if (!string.IsNullOrEmpty(board.Desc))
				AddParameter("desc", board.Desc);

			if (!string.IsNullOrEmpty(board.IdOrganization))
				AddParameter("idOrganization", board.IdOrganization);
		}
	}
}
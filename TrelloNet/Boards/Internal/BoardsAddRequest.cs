using RestSharp;

namespace TrelloNet.Internal
{
	internal class BoardsAddRequest : RestRequest
	{
		public BoardsAddRequest(NewBoard board)
			: base("boards", Method.POST)
		{
			AddParameter("name", board.Name);
		}
	}
}
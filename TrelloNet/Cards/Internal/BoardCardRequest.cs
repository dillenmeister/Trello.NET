using RestSharp;

namespace TrelloNet.Internal
{
	internal class BoardCardRequest : BoardRequest
	{
		public BoardCardRequest(int id, IBoardId board)
			: base(board, "cards/{cardId}")
		{
			AddParameter("cardId", id, ParameterType.UrlSegment);
		}
	}
}
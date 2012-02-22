using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsWithShortIdRequest : BoardsRequest
	{
		public CardsWithShortIdRequest(int id, IBoardId board)
			: base(board, "cards/{cardId}")
		{
			AddParameter("cardId", id, ParameterType.UrlSegment);
		}
	}
}
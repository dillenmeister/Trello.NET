using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsRequest : RestRequest
	{
		public CardsRequest(ICardId cardId, string resource = "", Method method = Method.GET)
			: base("cards/{cardId}/" + resource, method)
		{
			AddParameter("cardId", cardId.GetCardId(), ParameterType.UrlSegment);
		}

		public CardsRequest(string cardId, string resource = "", Method method = Method.GET)
			: this(new CardId(cardId), resource, method)
		{			
		}
	}
}
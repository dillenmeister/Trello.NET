using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsRequest : RestRequest
	{
		public CardsRequest(ICardId card, string resource = "", Method method = Method.GET)
			: base("cards/{cardId}/" + resource, method)
		{
			Guard.NotNull(card, "card");
			AddParameter("cardId", card.GetCardId(), ParameterType.UrlSegment);
			AddParameter("attachments", "true");
		}

		public CardsRequest(string cardId, string resource = "", Method method = Method.GET)
			: this(new CardId(cardId), resource, method)
		{			
		}
	}
}
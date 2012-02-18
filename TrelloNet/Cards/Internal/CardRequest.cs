using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardRequest : RestRequest
	{
		public CardRequest(ICardId cardId, string resource = "", Method method = Method.GET)
			: base("cards/{cardId}/" + resource, method)
		{
			AddParameter("cardId", cardId.GetCardId(), ParameterType.UrlSegment);
		}

		public CardRequest(string cardId, string resource = "", Method method = Method.GET)
			: this(new CardId(cardId), resource, method)
		{			
		}
	}
}
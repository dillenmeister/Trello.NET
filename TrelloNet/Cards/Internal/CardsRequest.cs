using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsRequest : RestRequest
	{
		public CardsRequest(ICardId card, string resource = "", Method method = Method.GET, bool includeAllFields = true)
			: base("cards/{cardId}/" + resource, method)
		{
			Guard.NotNull(card, "card");
			AddParameter("cardId", card.GetCardId(), ParameterType.UrlSegment);
            if(includeAllFields) AddParameter("fields", "all");
			this.AddCommonCardParameters();
		}

		public CardsRequest(string cardId, string resource = "", Method method = Method.GET, bool includeAllFields = true)
			: this(new CardId(cardId), resource, method, includeAllFields)
		{			
		}
	}
}
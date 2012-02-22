using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsChangeDescriptionRequest : CardsRequest
	{
		public CardsChangeDescriptionRequest(ICardId card, string description)
			: base(card, "desc", Method.PUT)
		{
			this.AddValue(description);
		}
	}
}
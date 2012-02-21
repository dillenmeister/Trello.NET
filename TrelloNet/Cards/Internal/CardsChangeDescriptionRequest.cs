using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsChangeDescriptionRequest : CardRequest
	{
		public CardsChangeDescriptionRequest(ICardId card, string description)
			: base(card, "desc", Method.PUT)
		{
			this.AddValue(description);
		}
	}
}
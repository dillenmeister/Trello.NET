using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsChangeNameRequest : CardRequest
	{
		public CardsChangeNameRequest(ICardId card, string name)
			: base(card, "name", Method.PUT)
		{
			this.AddValue(name);
		}
	}
}
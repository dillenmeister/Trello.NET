using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsChangeNameRequest : CardsRequest
	{
		public CardsChangeNameRequest(ICardId card, string name)
			: base(card, "name", Method.PUT)
		{
			Guard.RequiredTrelloString(name, "name");
			this.AddValue(name);
		}
	}
}
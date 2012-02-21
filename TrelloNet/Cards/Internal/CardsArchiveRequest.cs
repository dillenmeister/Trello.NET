using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsArchiveRequest : CardRequest
	{
		public CardsArchiveRequest(ICardId card)
			: base(card, "closed", Method.PUT)
		{
			AddParameter("value", "true");
		}
	}
}
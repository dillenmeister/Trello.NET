using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsDeleteRequest : CardRequest
	{
		public CardsDeleteRequest(ICardId card)
			: base(card, method: Method.DELETE)
		{			
		}
	}
}
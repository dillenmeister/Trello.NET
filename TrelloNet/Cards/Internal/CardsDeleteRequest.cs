using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsDeleteRequest : CardsRequest
	{
		public CardsDeleteRequest(ICardId card)
			: base(card, method: Method.DELETE)
		{			
		}
	}
}
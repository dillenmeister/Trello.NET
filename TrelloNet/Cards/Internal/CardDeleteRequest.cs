using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardDeleteRequest : CardRequest
	{
		public CardDeleteRequest(ICardId card)
			: base(card, method: Method.DELETE)
		{			
		}
	}
}
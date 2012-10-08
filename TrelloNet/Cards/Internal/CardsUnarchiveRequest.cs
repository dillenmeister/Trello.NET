using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsUnarchiveRequest : CardsRequest
	{
		public CardsUnarchiveRequest(ICardId card)
			: base(card, "closed", Method.PUT)
		{
			this.AddValue("false");			
		}
	}
}
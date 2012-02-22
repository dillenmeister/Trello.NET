using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsArchiveRequest : CardsRequest
	{
		public CardsArchiveRequest(ICardId card)
			: base(card, "closed", Method.PUT)
		{
			this.AddValue("true");			
		}
	}
}
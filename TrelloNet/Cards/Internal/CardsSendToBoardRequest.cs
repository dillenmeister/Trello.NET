using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsSendToBoardRequest : CardRequest
	{
		public CardsSendToBoardRequest(ICardId card)
			: base(card, "closed", Method.PUT)
		{
			this.AddValue("false");			
		}
	}
}
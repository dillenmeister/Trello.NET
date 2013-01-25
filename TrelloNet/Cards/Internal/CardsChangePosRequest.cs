using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsChangePosRequest : CardsRequest
	{
		public CardsChangePosRequest(ICardId card, double pos)
			: base(card, "pos", Method.PUT)
		{
			this.AddValue(pos);
		}

		public CardsChangePosRequest(ICardId card, Position pos)
			: base(card, "pos", Method.PUT)
		{
			this.AddValue(pos.ToTrelloString());
		}
	}
}
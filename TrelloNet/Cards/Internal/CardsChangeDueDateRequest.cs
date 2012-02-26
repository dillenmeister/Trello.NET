using System;
using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsChangeDueDateRequest : CardsRequest
	{
		public CardsChangeDueDateRequest(ICardId card, DateTimeOffset? due)
			: base(card, "due", Method.PUT)
		{
			this.AddValue(due);
		}
	}
}
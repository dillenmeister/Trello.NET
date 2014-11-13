using RestSharp;
using System;

namespace TrelloNet.Internal
{
	internal class CardsAddLabelRequest : CardsRequest
	{
		public CardsAddLabelRequest(ICardId card, String color)
			: base(card, "labels", Method.POST)
		{
			this.AddValue(color);
		}
	}
}
using RestSharp;
using System;

namespace TrelloNet.Internal
{
	internal class CardsRemoveLabelRequest : CardsRequest
	{
		public CardsRemoveLabelRequest(ICardId card, String color)
			: base(card, "labels/{color}", Method.DELETE)
		{
			AddParameter("color", color, ParameterType.UrlSegment);
		}
	}
}
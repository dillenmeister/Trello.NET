using System;
using System.Globalization;
using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsUpdateRequest : CardsRequest
	{
		public CardsUpdateRequest(IUpdatableCard card)
			: base(card.Id, method: Method.PUT)
		{
			Guard.RequiredTrelloString(card.Name, "name");
			Guard.OptionalTrelloString(card.Desc, "desc");
			Guard.NotNullOrEmpty(card.IdList, "idList");

			AddParameter("name", card.Name);
			AddParameter("desc", card.Desc);
			AddParameter("closed", card.Closed.ToTrelloString());
			AddParameter("idList", card.IdList);
			AddParameter("due", card.Due == null ? null : new DateTimeOffset(card.Due.Value).ToString(CultureInfo.InvariantCulture));
		}
	}
}
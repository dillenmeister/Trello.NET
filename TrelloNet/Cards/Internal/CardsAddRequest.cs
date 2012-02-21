using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsAddRequest : RestRequest
	{
		public CardsAddRequest(NewCard card)
			: base("cards", Method.POST)
		{
			AddParameter("name", card.Name);
			AddParameter("idList", card.IdList);

			if (!string.IsNullOrEmpty(card.Desc))
				AddParameter("desc", card.Desc);
		}
	}
}
using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardRequest : RestRequest
	{
		public CardRequest(string cardId, string resource = "", Method method = Method.GET)
			: base("cards/{cardId}/" + resource, method)
		{
			AddParameter("cardId", cardId, ParameterType.UrlSegment);
		}
	}
}
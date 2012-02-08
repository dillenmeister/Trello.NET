using RestSharp;

namespace TrelloNet.Internal.Requests
{
	internal class ListCardsRequest : ListRequest
	{
		public ListCardsRequest(string listId, CardFilter filter)
			: base(listId, "cards")
		{			
			AddParameter("labels", "true", ParameterType.GetOrPost);
			this.AddFilter(filter);
		}
	}
}
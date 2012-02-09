using RestSharp;

namespace TrelloNet.Internal.Requests
{
	internal class ListCardsRequest : ListRequest
	{
		public ListCardsRequest(IListId listId, CardFilter filter)
			: base(listId, "cards")
		{			
			AddParameter("labels", "true", ParameterType.GetOrPost);
			this.AddFilter(filter);
		}
	}
}
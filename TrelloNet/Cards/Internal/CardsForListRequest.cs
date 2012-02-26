using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsForListRequest : ListsRequest
	{
		public CardsForListRequest(IListId listId, CardFilter filter)
			: base(listId, "cards")
		{			
			AddParameter("labels", "true", ParameterType.GetOrPost);
			AddParameter("badges", "true", ParameterType.GetOrPost);
			AddParameter("checkItemStates", "true");
			this.AddFilter(filter);
		}
	}
}
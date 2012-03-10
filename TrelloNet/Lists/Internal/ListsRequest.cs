using RestSharp;

namespace TrelloNet.Internal
{
	internal class ListsRequest : RestRequest
	{
		public ListsRequest(IListId list, string resource = "", Method method = Method.GET)
			: base("list/{listId}/" + resource, method)
		{
			Guard.NotNull(list, "list");
			AddParameter("listId", list.GetListId(), ParameterType.UrlSegment);			
		}

		public ListsRequest(string listId, string resource = "", Method method = Method.GET) 
			: this(new ListId(listId), resource, method)
		{			
		}
	}
}
using RestSharp;

namespace TrelloNet.Internal
{
	internal class ListsRequest : RestRequest
	{
		public ListsRequest(IListId listId, string resource = "", Method method = Method.GET)
			: base("list/{listId}/" + resource, method)
		{
			AddParameter("listId", listId.GetListId(), ParameterType.UrlSegment);			
		}

		public ListsRequest(string listId, string resource = "", Method method = Method.GET) 
			: this(new ListId(listId), resource, method)
		{			
		}
	}
}
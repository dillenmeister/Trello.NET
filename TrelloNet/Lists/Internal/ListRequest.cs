using RestSharp;

namespace TrelloNet.Internal
{
	internal class ListRequest : RestRequest
	{
		public ListRequest(IListId listId, string resource = "", Method method = Method.GET)
			: base("list/{listId}/" + resource, method)
		{
			AddParameter("listId", listId.GetListId(), ParameterType.UrlSegment);			
		}

		public ListRequest(string listId, string resource = "", Method method = Method.GET) 
			: this(new ListId(listId), resource, method)
		{			
		}
	}
}
using RestSharp;

namespace TrelloNet.Internal
{
	internal class ListRequest : RestRequest
	{
		public ListRequest(string listId, string resource = "", Method method = Method.GET)
			: base("list/{listId}/" + resource, method)
		{
			AddParameter("listId", listId, ParameterType.UrlSegment);			
		}
	}
}
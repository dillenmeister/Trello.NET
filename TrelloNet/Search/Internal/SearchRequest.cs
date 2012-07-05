using RestSharp;

namespace TrelloNet.Internal
{
	internal class SearchRequest : RestRequest
	{
		public SearchRequest(string query)
			: base("search")
		{
			AddParameter("query", query);
			AddParameter("board_fields", "name,desc,closed,idOrganization,pinned,url,prefs,labelNames");
		}
	}
}
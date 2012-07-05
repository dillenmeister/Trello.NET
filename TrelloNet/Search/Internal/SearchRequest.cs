using RestSharp;

namespace TrelloNet.Internal
{
	internal class SearchRequest : RestRequest
	{
		public SearchRequest(string query)
			: base("search")
		{
			AddParameter("query", query);
			AddParameter("board_fields", "all");
			AddParameter("member_fields", "all");
			AddParameter("organization_field", "all");
		}
	}
}
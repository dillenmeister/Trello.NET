using System.Collections.Generic;
using RestSharp;
using System.Linq;

namespace TrelloNet.Internal
{
	internal class SearchRequest : RestRequest
	{
		public SearchRequest(string query, IEnumerable<ModelType> modelTypes, int limit)
			: base("search")
		{
			Guard.RequiredTrelloString(query, "query");
			Guard.InRange(limit, 1, 1000, "limit");
			
			AddParameter("query", query);
			AddParameter("board_fields", "all");
			AddParameter("member_fields", "all");
			AddParameter("organization_field", "all");

			if(modelTypes != null && modelTypes.Any())
				AddParameter("modelTypes", string.Join(",", modelTypes.Select(f => f.ToTrelloString())));

			AddParameter("boards_limit", limit);
			AddParameter("cards_limit", limit);
			AddParameter("organizations_limit", limit);
			AddParameter("members_limit", limit);
			AddParameter("actions_limit", limit);
		}
	}
}
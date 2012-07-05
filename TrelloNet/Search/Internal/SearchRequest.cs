using System.Collections.Generic;
using RestSharp;
using System.Linq;

namespace TrelloNet.Internal
{
	internal class SearchRequest : RestRequest
	{
		public SearchRequest(string query, int limit, SearchFilter filter, IEnumerable<ModelType> modelTypes)
			: base("search")
		{
			Guard.RequiredTrelloString(query, "query");
			Guard.InRange(limit, 1, 1000, "limit");			

			AddParameter("query", query);

			AddParameter("board_fields", "all");
			AddParameter("member_fields", "all");
			AddParameter("organization_field", "all");

			AddParameter("boards_limit", limit);
			AddParameter("cards_limit", limit);
			AddParameter("organizations_limit", limit);
			AddParameter("members_limit", limit);
			AddParameter("actions_limit", limit);

			if (modelTypes != null && modelTypes.Any())
				AddParameter("modelTypes", string.Join(",", modelTypes.Select(f => f.ToTrelloString())));

			if (filter != null)
			{
				if (filter.Boards != null && filter.Boards.Any())
					AddParameter("idBoards", string.Join(",", filter.Boards.Select(b => b.GetBoardId())));
				if (filter.Organizations != null && filter.Organizations.Any())
					AddParameter("idOrganizations", string.Join(",", filter.Organizations.Select(o => o.GetOrganizationId())));
				if (filter.Cards != null && filter.Cards.Any())
					AddParameter("idCards", string.Join(",", filter.Cards.Select(c => c.GetCardId())));
			}
		}
	}
}
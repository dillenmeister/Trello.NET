using RestSharp;

namespace TrelloNet.Internal
{
	public static class RestRequestExtensions
	{
		public static void AddFilter(this RestRequest request, CardFilter filter)
		{
			if (filter != CardFilter.Open)
				request.AddParameter("filter", filter.ToTrelloString(), ParameterType.GetOrPost);
		}

		public static void AddFilter(this RestRequest request, MemberFilter filter)
		{
			if (filter != MemberFilter.All)
				request.AddParameter("filter", filter.ToTrelloString(), ParameterType.GetOrPost);
		}

		public static void AddFilter(this RestRequest request, BoardFilter filter)
		{
			if (filter != BoardFilter.All)
				request.AddParameter("filter", filter.ToTrelloString(), ParameterType.GetOrPost);
		}

		public static void AddFilter(this RestRequest request, OrganizationFilter filter)
		{
			if (filter != OrganizationFilter.All)
				request.AddParameter("filter", filter.ToTrelloString(), ParameterType.GetOrPost);
		}
	}
}
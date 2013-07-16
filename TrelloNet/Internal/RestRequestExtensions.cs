using System;
using System.Collections.Generic;
using RestSharp;
using System.Linq;

namespace TrelloNet.Internal
{
	internal static class RestRequestExtensions
	{
		public static void AddFilter(this RestRequest request, Enum filter, string parameterName = "filter")
		{
			request.AddParameter(parameterName, filter.ToTrelloString(), ParameterType.GetOrPost);
		}

		public static void AddPaging(this RestRequest request, Paging paging)
		{
			if (paging == null)
				return;

			request.AddParameter("limit", paging.Limit, ParameterType.GetOrPost);
			request.AddParameter("page", paging.Page, ParameterType.GetOrPost);
		}

		public static void AddValue(this RestRequest request, object value)
		{
			request.AddParameter("value", value);
		}

		public static void AddCommonCardParameters(this RestRequest request)
		{
			request.AddParameter("labels", "true");
			request.AddParameter("badges", "true");
			request.AddParameter("checkItemStates", "true");
			request.AddParameter("attachments", "true");
			request.AddParameter("checklists", "all");
		}
		
		public static void AddRequiredMemberFields(this RestRequest request)	
		{
			request.AddParameter("fields", "fullName,username,bio,url,avatarHash,initials,status");			
		}

		public static void AddSince(this RestRequest request, ISince since)
		{
			if (since == null) 
				return;

			if (since.LastView)
				request.AddParameter("since", "lastView");
			if (since.Date > DateTime.MinValue)
				request.AddParameter("since", since.Date.ToString("yyyy-MM-ddTHH:mm:ss.fffK"));
		}

		public static void AddTypeFilter(this RestRequest request, IEnumerable<ActionType> filters)
		{
			if (filters == null || !filters.Any())
				return;

			var filterString = string.Join(",", filters.Select(f => f.ToTrelloString()));
			request.AddParameter("filter", filterString, ParameterType.GetOrPost);
		}
	}
}
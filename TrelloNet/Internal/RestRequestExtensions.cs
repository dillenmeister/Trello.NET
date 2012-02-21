using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace TrelloNet.Internal
{
	internal static class RestRequestExtensions
	{
		public static void AddFilter(this RestRequest request, Enum filter, string parameterName = "filter")
		{
			if (Convert.ToInt32(filter) != 0)
				request.AddParameter(parameterName, filter.ToTrelloString(), ParameterType.GetOrPost);
		}

		public static void AddFilter(this RestRequest request, IEnumerable<NotificationType> filters, string parameterName = "filter")
		{
			if (filters == null || !filters.Any())
				return;

			var filterString = string.Join(",", filters.Select(f => f.ToTrelloString()));
			request.AddParameter(parameterName, filterString, ParameterType.GetOrPost);
		}

		public static void AddPaging(this RestRequest request, Paging paging)
		{
			if (paging == null || paging.IsDefault)
				return;

			request.AddParameter("limit", paging.Limit, ParameterType.GetOrPost);
			request.AddParameter("page", paging.Page, ParameterType.GetOrPost);
		}

		public static void AddValue(this RestRequest request, object value)
		{
			request.AddParameter("value", value);
		}
	}
}
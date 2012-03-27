using System;
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
		}
	}
}
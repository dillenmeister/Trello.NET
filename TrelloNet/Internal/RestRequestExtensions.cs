using System;
using RestSharp;

namespace TrelloNet.Internal
{
	internal static class RestRequestExtensions
	{
		public static void AddFilter(this RestRequest request, Enum filter)
		{
			if(Convert.ToInt32(filter) != 0)			
				request.AddParameter("filter", filter.ToTrelloString(), ParameterType.GetOrPost);
		}

	}
}
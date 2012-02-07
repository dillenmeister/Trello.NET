using System;
using RestSharp;

namespace TrelloNet.Internal
{
	public class ChecklistRequest : RestRequest
	{
		public ChecklistRequest(string checkListId, string resource = "")
			: base("checklists/{checkListId}/" + resource)
		{
			AddParameter("checkListId", checkListId, ParameterType.UrlSegment);
		}
	}
}
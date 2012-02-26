using RestSharp;

namespace TrelloNet.Internal
{
	internal class ChecklistsRequest : RestRequest
	{
		public ChecklistsRequest(IChecklistId checklistId, string resource = "", Method method = Method.GET)
			: base("checklists/{checkListId}/" + resource, method)
		{
			AddParameter("checkListId", checklistId.GetChecklistId(), ParameterType.UrlSegment);
		}

		public ChecklistsRequest(string checkListId, string resource = "")
			: this(new ChecklistId(checkListId), resource)
		{			
		}
	}
}
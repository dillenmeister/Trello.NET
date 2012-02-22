using RestSharp;

namespace TrelloNet.Internal
{
	internal class ChecklistsRequest : RestRequest
	{
		public ChecklistsRequest(IChecklistId checklistId, string resource = "")
			: base("checklists/{checkListId}/" + resource)
		{
			AddParameter("checkListId", checklistId.GetChecklistId(), ParameterType.UrlSegment);
		}

		public ChecklistsRequest(string checkListId, string resource = "")
			: this(new ChecklistId(checkListId), resource)
		{			
		}
	}
}
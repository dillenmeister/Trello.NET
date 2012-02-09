using RestSharp;

namespace TrelloNet.Internal.Requests
{
	internal class ChecklistRequest : RestRequest
	{
		public ChecklistRequest(IChecklistId checklistId, string resource = "")
			: base("checklists/{checkListId}/" + resource)
		{
			AddParameter("checkListId", checklistId.GetChecklistId(), ParameterType.UrlSegment);
		}

		public ChecklistRequest(string checkListId, string resource = "")
			: this(new ChecklistId(checkListId), resource)
		{			
		}
	}
}
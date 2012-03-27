using RestSharp;

namespace TrelloNet.Internal
{
	internal class ChecklistsRequest : RestRequest
	{
		public ChecklistsRequest(IChecklistId checklist, string resource = "", Method method = Method.GET)
			: base("checklists/{checkListId}/" + resource, method)
		{
			Guard.NotNull(checklist, "checklist");
			AddParameter("checkListId", checklist.GetChecklistId(), ParameterType.UrlSegment);
		}

		public ChecklistsRequest(string checkListId, string resource = "", Method method = Method.GET)
			: this(new ChecklistId(checkListId), resource, method)
		{			
		}
	}
}
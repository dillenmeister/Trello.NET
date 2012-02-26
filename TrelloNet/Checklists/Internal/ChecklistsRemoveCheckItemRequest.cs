using RestSharp;

namespace TrelloNet.Internal
{
	internal class ChecklistsRemoveCheckItemRequest : ChecklistsRequest
	{
		public ChecklistsRemoveCheckItemRequest(IChecklistId checklist, string checkItemId)
			: base(checklist, "checkitems/{idCheckItem}", Method.DELETE)
		{
			AddParameter("idCheckItem", checkItemId, ParameterType.UrlSegment);
		}
	}
}
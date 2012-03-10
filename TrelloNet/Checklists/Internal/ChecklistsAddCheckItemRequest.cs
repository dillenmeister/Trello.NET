using RestSharp;

namespace TrelloNet.Internal
{
	internal class ChecklistsAddCheckItemRequest : ChecklistsRequest
	{
		public ChecklistsAddCheckItemRequest(IChecklistId checklist, string name) 
			: base(checklist, "checkitems", Method.POST)
		{
			Guard.NotNullOrEmpty(name, "name");
			AddParameter("name", name);
		}
	}
}
using RestSharp;

namespace TrelloNet.Internal
{
	internal class ChecklistsChangeNameRequest : ChecklistsRequest
	{
		public ChecklistsChangeNameRequest(IChecklistId checklist, string name)
			: base(checklist, "name", Method.PUT)
		{			
			this.AddValue(name);
		}
	}
}
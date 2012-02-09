using RestSharp;

namespace TrelloNet.Internal.Requests
{
	internal class ChecklistCardsRequest : ChecklistRequest
	{
		public ChecklistCardsRequest(IChecklistId checklistId, CardFilter filter)
			: base(checklistId, "cards")
		{
			AddParameter("labels", "true", ParameterType.GetOrPost);
			this.AddFilter(filter);
		}
	}
}
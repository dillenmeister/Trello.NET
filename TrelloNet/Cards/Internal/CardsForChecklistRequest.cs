using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsForChecklistRequest : ChecklistsRequest
	{
		public CardsForChecklistRequest(IChecklistId checklistId, CardFilter filter)
			: base(checklistId, "cards")
		{
			AddParameter("labels", "true", ParameterType.GetOrPost);
			AddParameter("badges", "true", ParameterType.GetOrPost);
			AddParameter("checkItemStates", "true");
			this.AddFilter(filter);
		}
	}
}
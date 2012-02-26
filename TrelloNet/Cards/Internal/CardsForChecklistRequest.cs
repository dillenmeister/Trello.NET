namespace TrelloNet.Internal
{
	internal class CardsForChecklistRequest : ChecklistsRequest
	{
		public CardsForChecklistRequest(IChecklistId checklistId, CardFilter filter)
			: base(checklistId, "cards")
		{
			this.AddCommonCardParameters();
			this.AddFilter(filter);
		}
	}
}
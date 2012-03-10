namespace TrelloNet.Internal
{
	internal class CardsForChecklistRequest : ChecklistsRequest
	{
		public CardsForChecklistRequest(IChecklistId checklist, CardFilter filter)
			: base(checklist, "cards")
		{
			this.AddCommonCardParameters();
			this.AddFilter(filter);
		}
	}
}
namespace TrelloNet.Internal
{
	internal class ChecklistsForCardRequest : CardsRequest
	{
		public ChecklistsForCardRequest(ICardId card)
			: base(card, "checklists")
		{
		}
	}
}
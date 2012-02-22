namespace TrelloNet.Internal
{
	internal class ChecklistsForCardRequest : CardsRequest
	{
		public ChecklistsForCardRequest(ICardId cardId)
			: base(cardId, "checklists")
		{
		}
	}
}
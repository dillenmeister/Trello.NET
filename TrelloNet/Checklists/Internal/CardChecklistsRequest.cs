namespace TrelloNet.Internal
{
	internal class CardChecklistsRequest : CardRequest
	{
		public CardChecklistsRequest(ICardId cardId)
			: base(cardId, "checklists")
		{
		}
	}
}
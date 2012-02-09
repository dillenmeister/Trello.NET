namespace TrelloNet.Internal.Requests
{
	internal class CardChecklistsRequest : CardRequest
	{
		public CardChecklistsRequest(ICardId cardId)
			: base(cardId, "checklists")
		{
		}
	}
}
namespace TrelloNet.Internal.Requests
{
	internal class CardChecklistsRequest : CardRequest
	{
		public CardChecklistsRequest(string cardId)
			: base(cardId, "checklists")
		{
		}
	}
}
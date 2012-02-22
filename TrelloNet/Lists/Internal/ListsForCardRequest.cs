namespace TrelloNet.Internal
{
	internal class ListsForCardRequest : CardsRequest
	{
		public ListsForCardRequest(ICardId cardId)
			: base(cardId, "list")
		{
		}
	}
}
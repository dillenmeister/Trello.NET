namespace TrelloNet.Internal
{
	internal class ListsForCardRequest : CardsRequest
	{
		public ListsForCardRequest(ICardId card)
			: base(card, "list")
		{
		}
	}
}
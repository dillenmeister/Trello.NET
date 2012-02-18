namespace TrelloNet.Internal
{
	internal class CardListRequest : CardRequest
	{
		public CardListRequest(ICardId cardId)
			: base(cardId, "list")
		{
		}
	}
}
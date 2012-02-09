namespace TrelloNet.Internal.Requests
{
	internal class CardListRequest : CardRequest
	{
		public CardListRequest(ICardId cardId)
			: base(cardId, "list")
		{
		}
	}
}
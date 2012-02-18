namespace TrelloNet.Internal
{
	internal class CardBoardRequest : CardRequest
	{
		public CardBoardRequest(ICardId cardId)
			: base(cardId, "board")
		{
		}
	}
}
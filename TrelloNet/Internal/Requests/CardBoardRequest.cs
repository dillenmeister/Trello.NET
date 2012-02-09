namespace TrelloNet.Internal.Requests
{
	internal class CardBoardRequest : CardRequest
	{
		public CardBoardRequest(ICardId cardId)
			: base(cardId, "board")
		{
		}
	}
}
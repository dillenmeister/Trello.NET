namespace TrelloNet.Internal.Requests
{
	internal class CardBoardRequest : CardRequest
	{
		public CardBoardRequest(string cardId)
			: base(cardId, "board")
		{
		}
	}
}
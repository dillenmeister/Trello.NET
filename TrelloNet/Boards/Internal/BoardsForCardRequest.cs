namespace TrelloNet.Internal
{
	internal class BoardsForCardRequest : CardsRequest
	{
		public BoardsForCardRequest(ICardId cardId)
			: base(cardId, "board")
		{
		}
	}
}
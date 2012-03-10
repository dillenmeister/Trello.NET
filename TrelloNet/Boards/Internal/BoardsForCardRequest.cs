namespace TrelloNet.Internal
{
	internal class BoardsForCardRequest : CardsRequest
	{
		public BoardsForCardRequest(ICardId card)
			: base(card, "board")
		{
		}
	}
}
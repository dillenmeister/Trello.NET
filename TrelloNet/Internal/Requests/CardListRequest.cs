namespace TrelloNet.Internal.Requests
{
	internal class CardListRequest : CardRequest
	{
		public CardListRequest(string cardId)
			: base(cardId, "list")
		{
		}
	}
}
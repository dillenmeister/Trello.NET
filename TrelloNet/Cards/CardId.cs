using TrelloNet.Internal;

namespace TrelloNet
{
	public class CardId : ICardId
	{
		private readonly string _cardId;

		public CardId(string cardId)
		{
			Guard.NotNullOrEmpty(cardId, "cardId");

			_cardId = cardId;
		}

		public string GetCardId()
		{
			return _cardId;
		}
	}
}
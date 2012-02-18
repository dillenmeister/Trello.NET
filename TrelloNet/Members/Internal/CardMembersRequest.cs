namespace TrelloNet.Internal
{
	internal class CardMembersRequest : CardRequest
	{
		public CardMembersRequest(ICardId cardId)
			: base(cardId, "members")
		{			
		}
	}
}
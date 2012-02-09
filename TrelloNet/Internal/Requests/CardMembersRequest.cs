namespace TrelloNet.Internal.Requests
{
	internal class CardMembersRequest : CardRequest
	{
		public CardMembersRequest(ICardId cardId)
			: base(cardId, "members")
		{			
		}
	}
}
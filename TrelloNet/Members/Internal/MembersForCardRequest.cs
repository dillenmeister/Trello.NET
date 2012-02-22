namespace TrelloNet.Internal
{
	internal class MembersForCardRequest : CardsRequest
	{
		public MembersForCardRequest(ICardId cardId)
			: base(cardId, "members")
		{			
		}
	}
}
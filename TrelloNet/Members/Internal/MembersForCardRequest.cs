namespace TrelloNet.Internal
{
	internal class MembersForCardRequest : CardsRequest
	{
		public MembersForCardRequest(ICardId card)
			: base(card, "members")
		{			
		}
	}
}
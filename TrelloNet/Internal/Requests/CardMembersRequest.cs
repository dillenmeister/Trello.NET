namespace TrelloNet.Internal.Requests
{
	internal class CardMembersRequest : CardRequest
	{
		public CardMembersRequest(string cardId)
			: base(cardId, "members")
		{			
		}
	}
}
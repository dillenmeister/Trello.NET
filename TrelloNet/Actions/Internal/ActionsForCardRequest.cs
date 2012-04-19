namespace TrelloNet.Internal
{
	internal class ActionsForCardRequest : CardsRequest
	{
		public ActionsForCardRequest(ICardId card, ISince since, Paging paging)
			: base(card, "actions")
		{
			this.AddSince(since);
			this.AddPaging(paging);
		}
	}
}
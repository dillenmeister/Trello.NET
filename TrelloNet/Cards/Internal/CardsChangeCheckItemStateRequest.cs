namespace TrelloNet.Internal
{
	internal class CardsChangeCheckItemStateRequest : CardChangeCheckItemRequest
	{
		public CardsChangeCheckItemStateRequest(ICardId card, IChecklistId checkList, ICheckItemId checkItem, bool check)
			: base(card, checkList, checkItem, "state")
		{
			this.AddValue(check.ToTrelloString());
		}
	}
}
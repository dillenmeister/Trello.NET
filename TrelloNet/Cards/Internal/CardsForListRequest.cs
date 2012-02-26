namespace TrelloNet.Internal
{
	internal class CardsForListRequest : ListsRequest
	{
		public CardsForListRequest(IListId listId, CardFilter filter)
			: base(listId, "cards")
		{
			this.AddCommonCardParameters();
			this.AddFilter(filter);
		}
	}
}
namespace TrelloNet.Internal
{
	internal class CardsForListRequest : ListsRequest
	{
		public CardsForListRequest(IListId list, CardFilter filter)
			: base(list, "cards")
		{
			this.AddCommonCardParameters();
			this.AddFilter(filter);
		}
	}
}
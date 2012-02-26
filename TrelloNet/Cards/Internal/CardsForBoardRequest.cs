namespace TrelloNet.Internal
{
	internal class CardsForBoardRequest : BoardsRequest
	{
		public CardsForBoardRequest(IBoardId boardId, CardFilter filter)
			: base(boardId, "cards")
		{
			this.AddCommonCardParameters();
			this.AddFilter(filter);
		}
	}
}
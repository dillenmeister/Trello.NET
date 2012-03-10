namespace TrelloNet.Internal
{
	internal class CardsForBoardRequest : BoardsRequest
	{
		public CardsForBoardRequest(IBoardId board, CardFilter filter)
			: base(board, "cards")
		{
			this.AddCommonCardParameters();
			this.AddFilter(filter);
		}
	}
}
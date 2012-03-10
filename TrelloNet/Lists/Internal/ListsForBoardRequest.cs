namespace TrelloNet.Internal
{
	internal class ListsForBoardRequest : BoardsRequest
	{
		public ListsForBoardRequest(IBoardId board, ListFilter filter)
			: base(board, "lists")
		{
			this.AddFilter(filter);
		}
	}
}
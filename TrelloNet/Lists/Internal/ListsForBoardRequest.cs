namespace TrelloNet.Internal
{
	internal class ListsForBoardRequest : BoardsRequest
	{
		public ListsForBoardRequest(IBoardId boardId, ListFilter filter)
			: base(boardId, "lists")
		{
			this.AddFilter(filter);
		}
	}
}
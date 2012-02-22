namespace TrelloNet.Internal
{
	internal class BoardsForListRequest : ListsRequest
	{
		public BoardsForListRequest(IListId listId)
			: base(listId, "board")
		{
		}
	}
}
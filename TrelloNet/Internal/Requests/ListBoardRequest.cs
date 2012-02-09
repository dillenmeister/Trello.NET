namespace TrelloNet.Internal.Requests
{
	internal class ListBoardRequest : ListRequest
	{
		public ListBoardRequest(IListId listId)
			: base(listId, "board")
		{
		}
	}
}
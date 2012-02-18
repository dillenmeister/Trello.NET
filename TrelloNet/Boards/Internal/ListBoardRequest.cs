namespace TrelloNet.Internal
{
	internal class ListBoardRequest : ListRequest
	{
		public ListBoardRequest(IListId listId)
			: base(listId, "board")
		{
		}
	}
}
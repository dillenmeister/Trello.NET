namespace TrelloNet.Internal.Requests
{
	internal class ListBoardRequest : ListRequest
	{
		public ListBoardRequest(string listId)
			: base(listId, "board")
		{
		}
	}
}
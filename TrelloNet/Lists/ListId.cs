using TrelloNet.Internal;

namespace TrelloNet
{
	public class ListId : IListId
	{
		private readonly string _listId;

		public ListId(string listId)
		{
			Guard.NotNullOrEmpty(listId, "listId");

			_listId = listId;
		}

		public string GetListId()
		{
			return _listId;
		}
	}
}
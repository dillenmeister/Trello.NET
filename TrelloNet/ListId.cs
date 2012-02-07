namespace TrelloNet
{
	public class ListId : IListId
	{
		private readonly string _id;

		public ListId(string id)
		{
			_id = id;
		}

		public string GetListId()
		{
			return _id;
		}
	}
}
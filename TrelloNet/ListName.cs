namespace TrelloNet
{
	public class ListName : IListId
	{
		public string Id { get; set; }
		public string Name { get; set; }

		public string GetListId()
		{
			return Id;
		}
	}
}
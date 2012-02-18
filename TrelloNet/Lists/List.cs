namespace TrelloNet
{
	public class List : IListId
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public bool Closed { get; set; }
		public string IdBoard { get; set; }

		public string GetListId()
		{
			return Id;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
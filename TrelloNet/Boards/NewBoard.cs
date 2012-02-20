namespace TrelloNet
{
	public class NewBoard
	{		
		public string Name { get; set; }
		public string Desc { get; set; }
		public string IdOrganization { get; set; }

		public NewBoard(string name)
		{
			Name = name;
		}
	}
}
using TrelloNet.Internal;

namespace TrelloNet
{
	public class NewBoard
	{		
		public string Name { get; set; }
		public string Desc { get; set; }
		public string IdOrganization { get; set; }

		public NewBoard(string name)
		{
			Guard.NotNullOrEmpty(name, "name");
			Name = name;
		}
	}
}
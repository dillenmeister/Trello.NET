using TrelloNet.Internal;

namespace TrelloNet
{
	public class NewCard
	{
		public string Name { get; set; }
		public string IdList { get; set; }
		public string Desc { get; set; }

		public NewCard(string name, IListId list)
		{
			Guard.NotNullOrEmpty(name, "name");
			Guard.NotNull(list, "list");

			Name = name;
			IdList = list.GetListId();
		}
	}
}
using TrelloNet.Internal;

namespace TrelloNet
{
	public class NewCard
	{
		/// <summary>
		/// A string with a length from 1 to 16384 (required).
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Id of the list that the card should be added to (required).
		/// </summary>
		public IListId IdList { get; set; }

		/// <summary>
		/// A string with a length from 1 to 16384 (optional).
		/// </summary>
		public string Desc { get; set; }

		/// <param name="name">A string with a length from 1 to 16384.</param>
		/// <param name="list">Id of the list that the card should be added to.</param>
		public NewCard(string name, IListId list)
		{
			Name = name;
			IdList = list;
		}
	}
}
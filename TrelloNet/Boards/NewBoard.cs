namespace TrelloNet
{
	public class NewBoard
	{		
		/// <summary>
		/// A string with a length from 1 to 16384 (required).
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// A string with a length from 1 to 16384 (optional).
		/// </summary>
		public string Desc { get; set; }

		/// <summary>
		///  The id or name of the organization to add the board to (optional).
		/// </summary>
		public string IdOrganization { get; set; }

		/// <param name="name">A string with a length from 1 to 16384.</param>
		public NewBoard(string name)
		{
			Name = name;
		}
	}
}
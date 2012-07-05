using System.Collections.Generic;

namespace TrelloNet
{
	public class SearchResults
	{
		public SearchResults()
		{
			Boards = new List<Board>();
			Cards = new List<Card>();
			Organizations = new List<Organization>();
			Members = new List<Member>();
			Actions = new List<Action>();
		}

		public List<Board> Boards { get; set; }
		public List<Card> Cards { get; set; }
		public List<Organization> Organizations { get; set; }
		public List<Member> Members { get; set; }
		public List<Action> Actions { get; set; }		
	}
}
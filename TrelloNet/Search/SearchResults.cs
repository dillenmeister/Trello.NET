using System.Collections.Generic;

namespace TrelloNet
{
	public class SearchResults
	{			
		public IEnumerable<Board> Boards { get; set; }
		public IEnumerable<Card> Cards { get; set; }
		public IEnumerable<Organization> Organizations { get; set; }
		public IEnumerable<Member> Members { get; set; }
		public IEnumerable<Action> Actions { get; set; }		
	}
}
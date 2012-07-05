using System.Collections.Generic;

namespace TrelloNet
{
	public class SearchFilter
	{		
		public IEnumerable<IBoardId> Boards { get; set; }
		public IEnumerable<IOrganizationId> Organizations { get; set; }
		public IEnumerable<ICardId> Cards { get; set; }
	}
}
using System.Collections.Generic;
namespace TrelloNet.Internal
{
	internal class CardsForListRequest : ListsRequest
	{
        public CardsForListRequest(IListId list, CardFilter filter, IEnumerable<ActionType> includeActions = null)
			: base(list, "cards")
		{
			this.AddCommonCardParameters();
			this.AddFilter(filter);
            this.AddTypeInclude(includeActions);
            
		}
	}
}
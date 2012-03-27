using RestSharp;

namespace TrelloNet.Internal
{
	internal class ListsUpdateRequest : ListsRequest
	{
		public ListsUpdateRequest(IUpdatableList list)
			: base(list.Id, method: Method.PUT)
		{
			Guard.RequiredTrelloString(list.Name, "name");

			AddParameter("name", list.Name);			
			AddParameter("closed", list.Closed.ToTrelloString());
		}
	}
}
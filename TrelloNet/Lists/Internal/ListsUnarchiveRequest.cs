using RestSharp;

namespace TrelloNet.Internal
{
	internal class ListsUnarchiveRequest : ListsRequest
	{
		public ListsUnarchiveRequest(IListId list)
			: base(list, "closed", Method.PUT)
		{
			this.AddValue("false");			
		}
	}
}
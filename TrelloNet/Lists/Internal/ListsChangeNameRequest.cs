using RestSharp;

namespace TrelloNet.Internal
{
	internal class ListsChangeNameRequest : ListsRequest
	{
		public ListsChangeNameRequest(IListId list, string name)
			: base(list, "name", Method.PUT)
		{
			Guard.NotNullOrEmpty(name, "name");
			this.AddValue(name);			
		}
	}
}
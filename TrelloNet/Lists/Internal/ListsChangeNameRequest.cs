using RestSharp;

namespace TrelloNet.Internal
{
	internal class ListsChangeNameRequest : ListRequest
	{
		public ListsChangeNameRequest(IListId list, string name)
			: base(list, "name", Method.PUT)
		{
			this.AddValue(name);			
		}
	}
}
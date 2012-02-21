using RestSharp;

namespace TrelloNet.Internal
{
	internal class ListsArchiveRequest : ListRequest
	{
		public ListsArchiveRequest(IListId list)
			: base(list, "closed", Method.PUT)
		{
			this.AddValue("true");			
		}
	}
}
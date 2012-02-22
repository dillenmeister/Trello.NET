using RestSharp;

namespace TrelloNet.Internal
{
	internal class ListsSendToBoardRequest : ListsRequest
	{
		public ListsSendToBoardRequest(IListId list)
			: base(list, "closed", Method.PUT)
		{
			this.AddValue("false");			
		}
	}
}
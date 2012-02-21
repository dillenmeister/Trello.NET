using RestSharp;

namespace TrelloNet.Internal
{
	internal class ListsSendToBoardRequest : ListRequest
	{
		public ListsSendToBoardRequest(IListId list)
			: base(list, "closed", Method.PUT)
		{
			this.AddValue("false");			
		}
	}
}
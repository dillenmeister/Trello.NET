using RestSharp;

namespace TrelloNet.Internal
{
	internal class ListsAddRequest : RestRequest
	{
		public ListsAddRequest(NewList list)
			: base("lists", Method.POST)
		{
			Guard.NotNull(list, "list");

			AddParameter("name", list.Name);
			AddParameter("idBoard", list.IdBoard);	
		}
	}
}
using RestSharp;

namespace TrelloNet.Internal
{
	internal class ListsAddRequest : RestRequest
	{
		public ListsAddRequest(NewList list)
			: base("lists", Method.POST)
		{
			AddParameter("name", list.Name);
			AddParameter("idBoard", list.IdBoard);	
		}
	}
}
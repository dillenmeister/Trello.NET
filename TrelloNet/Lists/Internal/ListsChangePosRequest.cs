using RestSharp;

namespace TrelloNet.Internal
{
	internal class ListsChangePosRequest : ListsRequest
	{
		public ListsChangePosRequest(IListId list, double pos)
			: base(list, "pos", Method.PUT)
		{
			Guard.Positive(pos, "pos");
			this.AddValue(pos);
		}

		public ListsChangePosRequest(IListId list, Position pos)
			: base(list, "pos", Method.PUT)
		{
			this.AddValue(pos.ToTrelloString());
		}
	}
}
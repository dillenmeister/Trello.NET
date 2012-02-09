using RestSharp;

namespace TrelloNet.Internal.Requests
{
	internal class BoardListsRequest : BoardRequest
	{
		public BoardListsRequest(IBoardId boardId, ListFilter filter)
			: base(boardId, "lists")
		{
			if (filter != ListFilter.None)
				AddParameter("filter", filter.ToTrelloString(), ParameterType.GetOrPost);
		}
	}
}
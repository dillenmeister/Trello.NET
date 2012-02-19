using RestSharp;

namespace TrelloNet.Internal
{
	internal class BoardCardsRequest : BoardRequest
	{
		public BoardCardsRequest(IBoardId boardId, CardFilter filter)
			: base(boardId, "cards")
		{			
			AddParameter("labels", "true", ParameterType.GetOrPost);
			AddParameter("badges", "true", ParameterType.GetOrPost);
			this.AddFilter(filter);
		}
	}
}
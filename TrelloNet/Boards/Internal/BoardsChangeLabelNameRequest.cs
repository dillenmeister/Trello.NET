using RestSharp;

namespace TrelloNet.Internal
{
	internal class BoardsChangeLabelNameRequest : BoardsRequest
	{
		public BoardsChangeLabelNameRequest(IBoardId board, Color color, string name)
			: base(board, "labelNames/{color}", Method.PUT)
		{
			AddParameter("color", color.ColorName, ParameterType.UrlSegment);
			this.AddValue(name ?? "");
		}
	}
}
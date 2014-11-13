using RestSharp;
using System;

namespace TrelloNet.Internal
{
	internal class BoardsChangeLabelNameRequest : BoardsRequest
	{
		public BoardsChangeLabelNameRequest(IBoardId board, String color, string name)
			: base(board, "labelNames/{color}", Method.PUT)
		{
			AddParameter("color", color, ParameterType.UrlSegment);
			this.AddValue(name ?? "");
		}
	}
}
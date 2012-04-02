namespace TrelloNet.Internal
{
	internal class BoardsWithIdRequest : BoardsRequest
	{
		public BoardsWithIdRequest(string boardId) : base(boardId)
		{
			AddParameter("fields", "name,desc,closed,idOrganization,pinned,url,prefs,labelNames");
		}
	}
}
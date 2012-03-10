using RestSharp;

namespace TrelloNet.Internal
{
	internal class ChecklistsAddRequest : BoardsRequest
	{
		public ChecklistsAddRequest(IBoardId board, string name)
			: base(board, "checklists", Method.POST)
		{
			Guard.NotNullOrEmpty(name, "name");
			AddParameter("name", name);
		}
	}
}
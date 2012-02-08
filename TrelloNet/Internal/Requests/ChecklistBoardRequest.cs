namespace TrelloNet.Internal.Requests
{
	internal class ChecklistBoardRequest : ChecklistRequest
	{
		public ChecklistBoardRequest(string checkListId)
			: base(checkListId, "board")
		{
		}
	}
}
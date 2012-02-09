namespace TrelloNet.Internal.Requests
{
	internal class ChecklistBoardRequest : ChecklistRequest
	{
		public ChecklistBoardRequest(IChecklistId checkListId)
			: base(checkListId, "board")
		{
		}
	}
}
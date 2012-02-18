namespace TrelloNet.Internal
{
	internal class ChecklistBoardRequest : ChecklistRequest
	{
		public ChecklistBoardRequest(IChecklistId checkListId)
			: base(checkListId, "board")
		{
		}
	}
}
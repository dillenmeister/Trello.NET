namespace TrelloNet.Internal
{
	internal class BoardsForChecklistRequest : ChecklistsRequest
	{
		public BoardsForChecklistRequest(IChecklistId checkListId)
			: base(checkListId, "board")
		{
		}
	}
}
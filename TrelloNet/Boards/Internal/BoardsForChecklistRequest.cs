namespace TrelloNet.Internal
{
	internal class BoardsForChecklistRequest : ChecklistsRequest
	{
		public BoardsForChecklistRequest(IChecklistId checkList)
			: base(checkList, "board")
		{
		}
	}
}
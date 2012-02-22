namespace TrelloNet.Internal
{
	internal class MembersForBoardRequest : BoardsRequest
	{
		public MembersForBoardRequest(IBoardId boardId, MemberFilter filter)
			: base(boardId, "members")
		{			
			this.AddFilter(filter);
		}
	}
}
namespace TrelloNet.Internal
{
	internal class MembersForBoardRequest : BoardsRequest
	{
		public MembersForBoardRequest(IBoardId board, MemberFilter filter)
			: base(board, "members")
		{			
			this.AddFilter(filter);
			this.AddRequiredMemberFields();
		}
	}
}
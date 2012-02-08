namespace TrelloNet.Internal.Requests
{
	internal class BoardMembersRequest : BoardRequest
	{
		public BoardMembersRequest(string boardId, MemberFilter filter)
			: base(boardId, "members")
		{			
			this.AddFilter(filter);
		}
	}
}
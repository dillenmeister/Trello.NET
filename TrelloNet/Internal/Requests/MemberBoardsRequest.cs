namespace TrelloNet.Internal.Requests
{
	internal class MemberBoardsRequest : MemberRequest
	{
		public MemberBoardsRequest(string memberIdOrUsername, BoardFilter filter)
			: base(memberIdOrUsername, "boards")
		{
			this.AddFilter(filter);
		}
	}
}
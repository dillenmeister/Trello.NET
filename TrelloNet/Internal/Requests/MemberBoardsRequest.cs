namespace TrelloNet.Internal.Requests
{
	internal class MemberBoardsRequest : MemberRequest
	{
		public MemberBoardsRequest(IMemberId member, BoardFilter filter)
			: base(member, "boards")
		{
			this.AddFilter(filter);
		}
	}
}
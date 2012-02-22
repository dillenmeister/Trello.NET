namespace TrelloNet.Internal
{
	internal class BoardsForMemberRequest : MembersRequest
	{
		public BoardsForMemberRequest(IMemberId member, BoardFilter filter)
			: base(member, "boards")
		{
			this.AddFilter(filter);
		}
	}
}
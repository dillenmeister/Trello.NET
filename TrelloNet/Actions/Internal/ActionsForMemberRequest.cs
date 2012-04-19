namespace TrelloNet.Internal
{
	internal class ActionsForMemberRequest : MembersRequest
	{
		public ActionsForMemberRequest(IMemberId member, ISince since, Paging paging)
			: base(member, "actions")
		{
			this.AddSince(since);
			this.AddPaging(paging);
		}
	}
}
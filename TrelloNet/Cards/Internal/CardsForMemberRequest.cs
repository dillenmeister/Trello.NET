namespace TrelloNet.Internal
{
	internal class CardsForMemberRequest : MembersRequest
	{
		public CardsForMemberRequest(IMemberId member, CardFilter filter)
			: base(member, "cards")
		{
			this.AddCommonCardParameters();
			this.AddFilter(filter);
		}
	}
}
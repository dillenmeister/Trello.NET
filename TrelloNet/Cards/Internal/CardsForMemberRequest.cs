using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsForMemberRequest : MembersRequest
	{
		public CardsForMemberRequest(IMemberId member, CardFilter filter)
			: base(member, "cards")
		{
			AddParameter("labels", "true", ParameterType.GetOrPost);
			AddParameter("badges", "true", ParameterType.GetOrPost);
			AddParameter("checkItemStates", "true");
			this.AddFilter(filter);
		}
	}
}
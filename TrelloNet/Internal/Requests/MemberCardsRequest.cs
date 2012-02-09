using RestSharp;

namespace TrelloNet.Internal.Requests
{
	internal class MemberCardsRequest : MemberRequest
	{
		public MemberCardsRequest(IMemberId member, CardFilter filter)
			: base(member, "cards")
		{
			AddParameter("labels", "true", ParameterType.GetOrPost);
			this.AddFilter(filter);
		}
	}
}
using RestSharp;

namespace TrelloNet.Internal.Requests
{
	internal class MemberCardsRequest : MemberRequest
	{
		public MemberCardsRequest(string memberIdOrUsername, CardFilter filter)
			: base(memberIdOrUsername, "cards")
		{
			AddParameter("labels", "true", ParameterType.GetOrPost);
			this.AddFilter(filter);
		}
	}
}
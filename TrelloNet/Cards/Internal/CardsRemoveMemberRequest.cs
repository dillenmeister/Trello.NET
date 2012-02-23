using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsRemoveMemberRequest : CardsRequest
	{
		public CardsRemoveMemberRequest(ICardId card, IMemberId member)
			: base(card, "members/{idMember}", Method.DELETE)
		{
			AddParameter("idMember", member.GetMemberId(), ParameterType.UrlSegment);
		}
	}
}
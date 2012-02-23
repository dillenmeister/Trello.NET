using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsAddMemberRequest : CardsRequest
	{
		public	CardsAddMemberRequest(ICardId card, IMemberId member) 
			: base(card, "members", Method.POST)
		{			
			this.AddValue(member.GetMemberId());
		}
	}
}
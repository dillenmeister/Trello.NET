using RestSharp;

namespace TrelloNet.Internal.Requests
{
	internal class MemberRequest : RestRequest
	{
		public MemberRequest(IMemberId member, string resource = "")
			: base("members/{memberIdOrUsername}/" + resource)
		{			
			AddParameter("memberIdOrUsername", member.GetMemberId(), ParameterType.UrlSegment);
		}

		public MemberRequest(string memberIdOrUsername, string resource = "")
			: this(new MemberId(memberIdOrUsername), resource)
		{
		}
	}
}
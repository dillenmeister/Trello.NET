using RestSharp;

namespace TrelloNet.Internal
{
	internal class MembersRequest : RestRequest
	{
		public MembersRequest(IMemberId member, string resource = "")
			: base("members/{memberIdOrUsername}/" + resource)
		{			
			AddParameter("memberIdOrUsername", member.GetMemberId(), ParameterType.UrlSegment);
		}

		public MembersRequest(string memberIdOrUsername, string resource = "")
			: this(new MemberId(memberIdOrUsername), resource)
		{
		}
	}
}
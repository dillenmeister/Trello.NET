using RestSharp;

namespace TrelloNet.Internal.Requests
{
	internal class MemberRequest : RestRequest
	{
		public MemberRequest(string memberIdOrUsername, string resource = "")
			: base("members/{memberIdOrUsername}/" + resource)
		{			
			AddParameter("memberIdOrUsername", memberIdOrUsername, ParameterType.UrlSegment);
		}
	}
}
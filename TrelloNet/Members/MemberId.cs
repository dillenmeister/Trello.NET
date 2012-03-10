using TrelloNet.Internal;

namespace TrelloNet
{
	public class MemberId : IMemberId
	{
		private readonly string _memberIdOrUsername;

		public MemberId(string memberIdOrUsername)
		{
			Guard.NotNullOrEmpty(memberIdOrUsername, "memberIdOrUsername");
			_memberIdOrUsername = memberIdOrUsername;
		}

		public string GetMemberId()
		{
			return _memberIdOrUsername;
		}
	}
}
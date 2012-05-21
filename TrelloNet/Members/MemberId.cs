using TrelloNet.Internal;

namespace TrelloNet
{
	public class MemberId : IMemberId
	{
		private readonly string _idOrUsername;

		public MemberId(string idOrUsername)
		{
			Guard.NotNullOrEmpty(idOrUsername, "idOrUsername");
			_idOrUsername = idOrUsername;
		}

		public string IdOrUsername
		{
			get { return _idOrUsername; }
		}

		public string GetMemberId()
		{
			return IdOrUsername;
		}
	}
}
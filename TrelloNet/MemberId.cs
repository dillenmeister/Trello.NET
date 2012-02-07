namespace TrelloNet
{
	public class MemberId : IMemberId
	{
		private readonly string _id;

		public MemberId(string id)
		{
			_id = id;
		}

		public string GetMemberId()
		{
			return _id;
		}
	}
}
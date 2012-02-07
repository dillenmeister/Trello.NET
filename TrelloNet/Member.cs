namespace TrelloNet
{
	public class Member : IMemberId
	{
		public string Id { get; set; }
		public string FullName { get; set; }
		public string Username { get; set; }
		public string Gravatar { get; set; }
		public string Bio { get; set; }
		public string Url { get; set; }

		public string GetMemberId()
		{
			return Id;
		}

		public override string ToString()
		{
			return FullName;
		}
	}	
}
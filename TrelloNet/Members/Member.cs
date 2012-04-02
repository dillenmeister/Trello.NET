namespace TrelloNet
{
	public class Member : IMemberId
	{
		public string Id { get; set; }
		public string FullName { get; set; }
		public string Username { get; set; }
		public string Bio { get; set; }
		public string Url { get; set; }
		public string AvatarHash { get; set; }
		public string GravatarHash { get; set; }
		public string UploadedAvatarHash { get; set; }
		public AvatarSource AvatarSource { get; set; }
		public MemberStatus Status { get; set; }
		public string Initials { get; set; }

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
using System;

namespace TrelloNet
{
	public class Action
	{
		public string Id { get; set; }
		public string IdMemberCreator { get; set; }
		public DateTime Date { get; set; }
		public Member MemberCreator { get; set; }

		public class Member : IMemberId
		{
			public string Id { get; set; }
			public string FullName { get; set; }
			public string Username { get; set; }
			public string AvatarHash { get; set; }
			public string Initials { get; set; }

			public string GetMemberId()
			{
				return Id;
			}
		}
	}
}
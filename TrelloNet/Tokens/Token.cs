using System;
using System.Collections.Generic;

namespace TrelloNet
{
	public class Token
	{
		public string Id { get; set; }
		public string IdMember { get; set; }
		public DateTime DateCreated { get; set; }

		public List<TokenPermissions> Permissions { get; set; }

		public class TokenPermissions
		{
			public string IdModel { get; set; }
			public string ModelType { get; set; }
			public bool Read { get; set; }
			public bool Write { get; set; }
		}
	}
}
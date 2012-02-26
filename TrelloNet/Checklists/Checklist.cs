using System.Collections.Generic;

namespace TrelloNet
{
	public class Checklist : IChecklistId
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string IdBoard { get; set; }

		public List<Ítem> CheckItems { get; set; }

		public class Ítem
		{
			public string Id { get; set; }
			public string Name { get; set; }
		}

		public override string ToString()
		{
			return Name;
		}

		public string GetChecklistId()
		{
			return Id;
		}
	}
}
using System.Collections.Generic;

namespace TrelloNet
{
	public class Checklist : IChecklistId, IUpdatableChecklist
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string IdBoard { get; set; }

		public List<CheckItem> CheckItems { get; set; }

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
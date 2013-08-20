using System.Collections.Generic;

namespace TrelloNet
{
	public class Checklist<TCheckItem> : IChecklistId, IUpdatableChecklist where TCheckItem : CheckItem
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string IdBoard { get; set; }
        public double Pos { get; set; }

        public List<TCheckItem> CheckItems { get; set; }

		public override string ToString()
		{
			return Name;
		}

		public string GetChecklistId()
		{
			return Id;
		}
	}

    public class Checklist : Checklist<CheckItem>
    {        
    }
}
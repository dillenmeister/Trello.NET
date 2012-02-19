using System;
using System.Collections.Generic;

namespace TrelloNet
{
	public class Card : ICardId
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Desc { get; set; }
		public bool Closed { get; set; }
		public string IdList { get; set; }
		public string IdBoard { get; set; }
		public DateTime? Due { get; set; }
		public List<Label> Labels { get; set; }
		public int IdShort { get; set; }
		public CardBadges Badges { get; set; }

		public string GetCardId()
		{
			return Id;
		}

		public override string ToString()
		{
			return Name;
		}

		public class Label
		{
			public string Color { get; set; }
			public string Name { get; set; }
		}

		public class CardBadges
		{
			public int Votes { get; set; }
			public DateTime? Due { get; set; }
			public bool Description { get; set; }
			public int Attachments { get; set; }
			public int Comments { get; set; }
			public int CheckItemsChecked { get; set; }
			public int CheckItems { get; set; }
			public string FogBugz { get; set; }
		}
	}
}
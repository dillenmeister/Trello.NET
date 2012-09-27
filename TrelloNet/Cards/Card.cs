using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TrelloNet
{
	public class Card : ICardId, IUpdatableCard
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
		public List<Checklist> Checklists { get; set; }
		public List<CheckItemState> CheckItemStates { get; set; }
		public List<Attachment> Attachments { get; set; }
		public string Url { get; set; }
		public double Pos { get; set; }

		public string GetCardId()
		{
			return Id;
		}

		public override string ToString()
		{
			return Name;
		}

		public class CheckItemState : ICheckItemId
		{
			[JsonProperty("_id")]
			public string Id { get; set; }
			public string IdCheckItem { get; set; }
			public string State { get; set; }

			public string GetCheckItemId()
			{
				return IdCheckItem;
			}
		}

		public class Label
		{
			public Color Color { get; set; }
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

		public class Attachment
		{
			public string Id { get; set; }
			public string IdMember { get; set; }
			public string Name { get; set; }
			public string Url { get; set; }
			public DateTime Date { get; set; }
		}
	}
}
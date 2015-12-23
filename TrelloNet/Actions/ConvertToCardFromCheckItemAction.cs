namespace TrelloNet
{
	public class ConvertToCardFromCheckItemAction : Action
	{
		public ActionData Data { get; set; }

		public class ActionData
		{
			public CardName CardSource { get; set; }
			public CardName Card { get; set; }
			public ListName List { get; set; }
			public BoardName Board { get; set; }
		}
	}
}
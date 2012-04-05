namespace TrelloNet
{
	public class UpdateCheckItemStateOnCardAction : Action
	{
		public ActionData Data { get; set; }

		public class ActionData
		{
			public BoardName Board { get; set; }
			public CardName Card { get; set; }
			public CheckItemWithState CheckItem { get; set; }
		}
	}
}
namespace TrelloNet
{
	public class ConvertToCardFromCheckItemAction : Action
	{
		public ActionData Data { get; set; }

		public class ActionData
		{
			public CardName CardSource { get; set; }
			public CardName Card { get; set; }
			public ChecklistName Checklist { get; set; }
			public BoardName Board { get; set; }
			public CheckItemName CheckItem { get; set; }
		}
	}
}
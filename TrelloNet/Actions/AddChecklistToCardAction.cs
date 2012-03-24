namespace TrelloNet
{
	public class AddChecklistToCardAction : Action
	{
		public ActionData Data { get; set; }

		public class ActionData
		{
			public BoardName Board { get; set; }
			public CardName Card { get; set; }
			public ChecklistName Checklist { get; set; }
		}
	}
}
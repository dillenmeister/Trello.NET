namespace TrelloNet
{
	public class RemoveChecklistFromCardAction : Action
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
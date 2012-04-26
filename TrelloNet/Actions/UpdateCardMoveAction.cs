namespace TrelloNet
{
	public class UpdateCardMoveAction : Action
	{
		public UpdateCardMoveAction()
		{
			Data = new ActionData();
		}

		public ActionData Data { get; set; }

		public class ActionData
		{
			public BoardName Board { get; set; }
			public CardName Card { get; set; }
			public ListName ListBefore { get; set; }
			public ListName ListAfter { get; set; }
		}
	}
}
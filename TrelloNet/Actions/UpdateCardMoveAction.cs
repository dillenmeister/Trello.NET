namespace TrelloNet
{
	public class UpdateCardMoveAction : Action
	{
		public UpdateCardMoveAction()
		{
			Data = new ActionData();
		}

		public ActionData Data { get; set; }

		public class ActionData: IUpdateData
		{
			public BoardName Board { get; set; }
			public CardName Card { get; set; }
			public ListName ListBefore { get; set; }
			public ListName ListAfter { get; set; }
		    public Old Old { get; set; }
		}
	}
}
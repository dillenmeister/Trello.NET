namespace TrelloNet
{
	public class UpdateCardAction : Action
	{
		public UpdateCardAction()
		{
			Data = new ActionData();
		}

		public ActionData Data { get; set; }

		public class ActionData : IUpdateData
		{
			public BoardName Board { get; set; }
			public CardName Card { get; set; }

			public dynamic OldValue { get; set; }
			public dynamic NewValue { get; set; }
			public string UpdatedProperty { get; set; }
		}
	}
}
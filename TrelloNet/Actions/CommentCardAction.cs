namespace TrelloNet
{
	public class CommentCardAction : Action
	{
		public ActionData Data { get; set; }

		public class ActionData
		{
			public BoardName Board { get; set; }
			public CardName Card { get; set; }
			public string Text { get; set; }
		}
	}
}
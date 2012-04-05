namespace TrelloNet
{
	public class CreateCardAction: Action
	{
		public ActionData Data { get; set; }

		public class ActionData
		{
			public BoardName Board { get; set; }
			public CardName Card { get; set; }
			public ListName List { get; set; }
		}
	}
}
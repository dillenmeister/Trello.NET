namespace TrelloNet
{
	public class MoveCardToBoardAction : Action
	{
		public ActionData Data { get; set; }

		public class ActionData
		{
			public BoardId BoardSource { get; set; }
			public BoardName Board { get; set; }
			public CardName Card { get; set; }
		}
	}
}
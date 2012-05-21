namespace TrelloNet
{
	public class MoveCardFromBoardAction : Action
	{
		public ActionData Data { get; set; }

		public class ActionData
		{
			public BoardId BoardTarget { get; set; }
			public BoardName Board { get; set; }
			public CardName Card { get; set; }
		}
	}
}
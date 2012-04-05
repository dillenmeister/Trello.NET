namespace TrelloNet
{
	public class CreateBoardAction : Action
	{
		public ActionData Data { get; set; }

		public class ActionData
		{
			public BoardName Board { get; set; }
		}
	}
}
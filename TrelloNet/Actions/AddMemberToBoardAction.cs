namespace TrelloNet
{
	public class AddMemberToBoardAction : Action
	{
		public ActionData Data { get; set; }

		public class ActionData
		{
			public BoardName Board { get; set; }
			public string IdMemberAdded { get; set; }
		}
	}
}
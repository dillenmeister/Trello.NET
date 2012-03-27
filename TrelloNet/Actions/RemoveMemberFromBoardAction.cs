namespace TrelloNet
{
	public class RemoveMemberFromBoardAction : Action
	{
		public ActionData Data { get; set; }

		public class ActionData
		{
			public BoardName Board { get; set; }
			public string IdMember { get; set; }
		}
	}
}
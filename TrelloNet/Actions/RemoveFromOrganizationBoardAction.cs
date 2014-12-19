namespace TrelloNet
{
	public class RemoveFromOrganizationBoardAction : Action
	{
		public ActionData Data { get; set; }

		public class ActionData
		{
			public BoardName Board { get; set; }
            public OrganizationName Organization { get; set; }
		}
	}
}
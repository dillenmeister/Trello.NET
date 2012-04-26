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

			public Old Old { get; set; }
		}
	}

	public class UpdateOrganizationAction : Action
	{
		public UpdateOrganizationAction()
		{
			Data = new ActionData();
		}

		public ActionData Data { get; set; }

		public class ActionData : IUpdateData
		{
			public OrganizationName Organization { get; set; }

			public Old Old { get; set; }
		}
	}
}
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

	public class CloseCardAction : Action
	{
		public CloseCardAction()
		{
			Data = new ActionData();
		}

		public ActionData Data { get; set; }

		public class ActionData : IUpdateData
		{
			public BoardName Board { get; set; }
			public CloseCardAction.CardName Card { get; set; }

			public Old Old { get; set; }
		}

		public class CardName : TrelloNet.CardName
		{
			public bool Closed { get; set; }
		}
	}

	public class UpdateCardPositionAction : Action
	{
		public UpdateCardPositionAction()
		{
			Data = new ActionData();
		}

		public ActionData Data { get; set; }

		public class ActionData : IUpdateData
		{
			public BoardName Board { get; set; }
			public UpdateCardPositionAction.CardName Card { get; set; }

			public Old Old { get; set; }
		}

		public class CardName : TrelloNet.CardName
		{
			public double Pos { get; set; }
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
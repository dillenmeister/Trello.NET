namespace TrelloNet
{
	public class UpdateListAction : Action
	{
		public UpdateListAction()
		{
			Data = new ActionData();
		}

		public ActionData Data { get; set; }

		public class ActionData : IUpdateData
		{
			public BoardName Board { get; set; }
			public ListName List { get; set; }

			public Old Old { get; set; }
		}
	}
}
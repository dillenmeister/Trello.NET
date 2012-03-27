namespace TrelloNet
{
	public class CreateListAction : Action
	{
		public ActionData Data { get; set; }

		public class ActionData
		{
			public BoardName Board { get; set; }
			public ListName List { get; set; }
		}
	}
}
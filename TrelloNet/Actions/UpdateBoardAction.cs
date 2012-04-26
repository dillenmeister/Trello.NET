namespace TrelloNet
{
	public class UpdateBoardAction : Action
	{
		public UpdateBoardAction()
		{
			Data = new ActionData();
		}

		public ActionData Data { get; set; }
		
		public class ActionData : IUpdateData
		{			
			public BoardName Board { get; set; }

			public dynamic OldValue { get; set; }
			public dynamic NewValue { get; set; }
			public string UpdatedProperty { get; set; }
		}		 
	}		
}
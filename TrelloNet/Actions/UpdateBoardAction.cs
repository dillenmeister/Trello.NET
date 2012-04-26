namespace TrelloNet
{
	public class UpdateBoardAction : Action
	{
		public ActionData Data { get; set; }
		
		public class ActionData
		{			
			public BoardName Board { get; set; }

			public dynamic OldValue { get; set; }
			public dynamic NewValue { get; set; }
			public string UpdatedProperty { get; set; }
		}		 
	}		
}
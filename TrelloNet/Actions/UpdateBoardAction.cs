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
			public Old Old { get; set; }			
		}		 
	}
}
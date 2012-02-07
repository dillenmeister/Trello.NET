namespace TrelloNet
{
	public class ChecklistId : IChecklistId
	{
		private readonly string _id;

		public ChecklistId(string id)
		{
			_id = id;
		}

		public string GetChecklistId()
		{
			return _id;
		}
	}
}
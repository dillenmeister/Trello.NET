namespace TrelloNet
{
	public class ChecklistName : IChecklistId
	{
		public string Id { get; set; }
		public string Name { get; set; }

		public string GetChecklistId()
		{
			return Id;
		}
	}
}
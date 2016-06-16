namespace TrelloNet
{
	public class CheckItem : ICheckItemId
	{
		public string Id { get; set; }
		public string Name { get; set; }
        public double Pos { get; set; }
        public string Status { get; set; }

		public string GetCheckItemId()
		{
			return Id;
		}
	}
}
namespace TrelloNet
{
	public class CardName : ICardId
	{
		public string Id { get; set; }
		public string Name { get; set; }

		public string GetCardId()
		{
			return Id;
		}
	}
}
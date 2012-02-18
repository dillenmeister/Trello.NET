namespace TrelloNet
{
	public class CardId : ICardId
	{
		private readonly string _id;

		public CardId(string id)
		{
			_id = id;
		}

		public string GetCardId()
		{
			return _id;
		}
	}
}
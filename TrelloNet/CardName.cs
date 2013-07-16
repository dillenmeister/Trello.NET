namespace TrelloNet
{
	public class CardName : ICardId
	{
		public string Id { get; set; }
		public string Name { get; set; }
        
        public int IdShort { get; set; }
        public bool Closed { get; set; }

        public double Pos { get; set; }

		public string GetCardId()
		{
			return Id;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
namespace TrelloNet
{
	public class TrelloUnauthorizedException : TrelloException
	{
		public TrelloUnauthorizedException(string message) : base(message)
		{			
		}
	}
}
using System;

namespace TrelloNet
{
	public class TrelloException : Exception
	{
		public TrelloException(string message) : base(message)
		{			
		}
	}
}
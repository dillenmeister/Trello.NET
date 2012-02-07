using System;

namespace TrelloNet
{
	public class UnauthorizedException : TrelloException
	{
		public UnauthorizedException(string message) : base(message)
		{			
		}
	}
}
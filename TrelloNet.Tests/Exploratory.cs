using System.Configuration;
using NUnit.Framework;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class Exploratory
	{
		[Test, Explicit]
		public void Demonstrate_Functionality()
		{
			var trello = new Trello(ConfigurationManager.AppSettings["ApplicationKey"]);
			trello.Authenticate(ConfigurationManager.AppSettings["MemberToken"]);			
		}
	}
}

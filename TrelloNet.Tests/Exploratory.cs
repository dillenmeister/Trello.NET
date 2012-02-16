using System.Configuration;
using System.Linq;
using NUnit.Framework;
using TrelloNet.Internal;

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

			var notifications = trello.Notifications.GetByMe(readFilter: ReadFilter.Unread, paging: new Paging(10, 1));			
		}
	}
}

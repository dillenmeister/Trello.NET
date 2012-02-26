using System.Configuration;
using NUnit.Framework;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class UnauthorizedTests : TrelloTestBase
	{
		[Test]
		public void InvalidToken_ShouldThrowUnauthorizedException()
		{
			var trello = new Trello(ConfigurationManager.AppSettings["ApplicationKey"]);
			trello.Authorize("invalid token");
			Assert.That(() => trello.Members.Me(), Throws.TypeOf<TrelloUnauthorizedException>());
		}

		[Test]
		public void NoToken_ShouldThrowUnauthorizedException()
		{
			var trello = new Trello(ConfigurationManager.AppSettings["ApplicationKey"]);
			Assert.That(() => trello.Boards.WithId(Constants.WelcomeBoardId), Throws.TypeOf<TrelloUnauthorizedException>());
		}
	}
}
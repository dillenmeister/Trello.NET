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
			trello.Authenticate("invalid token");
			Assert.That(() => trello.Members.Me(), Throws.TypeOf<UnauthorizedException>());
		}

		[Test]
		public void NoToken_ShouldThrowUnauthorizedException()
		{
			var trello = new Trello(ConfigurationManager.AppSettings["ApplicationKey"]);
			Assert.That(() => trello.Boards.WithId(Constants.WelcomeBoardId), Throws.TypeOf<UnauthorizedException>());
		}
	}
}
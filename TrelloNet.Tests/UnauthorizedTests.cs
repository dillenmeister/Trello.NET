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
			Assert.That(() => trello.Members.GetMe(), Throws.TypeOf<UnauthorizedException>());
		}

		[Test]
		public void NoToken_ShouldThrowUnauthorizedException()
		{
			var trello = new Trello(ConfigurationManager.AppSettings["ApplicationKey"]);
			Assert.That(() => trello.Board(Constants.WelcomeBoardId), Throws.TypeOf<UnauthorizedException>());
		}
	}
}
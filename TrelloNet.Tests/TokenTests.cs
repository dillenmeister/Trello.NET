using System;
using System.Collections.Generic;
using ExpectedObjects;
using NUnit.Framework;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class TokenTests : TrelloTestBase
	{
		[Test]
		public void WithToken_AToken_ReturnsExpectedToken()
		{
			var expected = new Token
			{
                Id = "548ea388f23678d905018f36",
				IdMember = Constants.MeId,
				DateCreated = new DateTime(2014, 12, 15, 09, 02, 00, 446),
				Permissions = new List<Token.TokenPermissions>
				{
					new Token.TokenPermissions
					{
						IdModel = "*",
						ModelType = "Board",
						Read = true,
						Write = false
					},
					new Token.TokenPermissions
					{
						IdModel = "*",
						ModelType = "Organization",
						Read = true,
						Write = false
					}
				}
			}.ToExpectedObject();

            var actual = _trelloReadOnly.Tokens.WithToken("4f1ecd33625aab4a75c3d19622b09dbe03e9944a9ec8c97adec2c1e9eaf585c3");

			expected.ShouldEqual(actual);
		}
	}
}
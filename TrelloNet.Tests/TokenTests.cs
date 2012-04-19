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
				Id = "4f588114f57acfa95fa5065b",
				IdMember = Constants.MeId,
				DateCreated = new DateTime(2012, 03, 08, 09, 51, 16, 806),
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

			var actual = _trelloReadOnly.Tokens.WithToken("a0f05ce01f11b4dceb1127e244bdc9c45705d44f3ec1b349f3f4a4c306e20fcf");

			expected.ShouldEqual(actual);
		}
	}
}
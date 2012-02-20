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
		public void WithId_AToken_ReturnsExpectedToken()
		{
			var expected = new Token
			{
				Id = "4f2b900cfa08ac1f1b4ae00d",
				IdMember = Constants.MeId,
				DateCreated = new DateTime(2012, 02, 03, 08, 43, 08, 478),
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

			var actual = _readTrello.Tokens.WithToken("34d12362615097b30d6140a8c596d8e8fd70d198fb6b3df7f6ab5605e4ec6f54");

			expected.ShouldEqual(actual);
		}
	}
}
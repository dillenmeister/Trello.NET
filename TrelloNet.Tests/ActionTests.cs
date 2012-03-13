using System;
using ExpectedObjects;
using NUnit.Framework;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class ActionTests : TrelloTestBase
	{
		[Test]
		public void WithId_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Actions.WithId(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "actionId"));
		}

		[Test]
		public void WithId_AnAction_ReturnsExpectedAction()
		{
			const string actionId = "4f3f58ee3374646b5c1693d7";
			var expected = new RemoveMemberFromCardAction
			{
				Id = actionId,
				IdMemberCreator = "4ece5a165237e5db06624a2a",
				Date = new DateTime(2012, 02, 18, 07, 53, 18, 696).ToLocalTime(),
				Data = new RemoveMemberFromCardAction.ActionData
				{
					Board = new BoardName
					{
						Id = "4f2b8b4d4f2cb9d16d3684c9",
						Name = "Welcome Board"
					},
					Card = new CardName
					{
						Id = "4f2b8b4d4f2cb9d16d368506",
						Name = "To learn more tricks, check out the guide."
					},
					IdMember = "4f2b8b464f2cb9d16d368326"
				}
			}.ToExpectedObject();

			var actual = _trelloReadOnly.Actions.WithId(actionId);

			expected.ShouldEqual(actual);
		}
	}
}
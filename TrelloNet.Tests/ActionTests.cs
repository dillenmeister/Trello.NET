using System;
using ExpectedObjects;
using NUnit.Framework;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class ActionTests : TrelloTestBase
	{
		private string _testUser = "4ece5a165237e5db06624a2a";

		[Test]
		public void WithId_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Actions.WithId(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "actionId"));
		}

		[Test]
		public void WithId_ARemoveMemberFromCardAction_ReturnsExpectedAction()
		{
			const string actionId = "4f3f58ee3374646b5c1693d7";
			var expected = new RemoveMemberFromCardAction
			{
				Id = actionId,
				IdMemberCreator = _testUser,
				Date = new DateTime(2012, 02, 18, 07, 53, 18, 696).ToLocalTime(),
				Data = new RemoveMemberFromCardAction.ActionData
				{
					Board = TheWelcomeBoard(),
					Card = TheLearnTricksCard(),
					IdMember = "4f2b8b464f2cb9d16d368326"
				}
			}.ToExpectedObject();

			var actual = _trelloReadOnly.Actions.WithId(actionId);

			expected.ShouldEqual(actual);
		}

		[Test]
		public void WithId_AnAddMemberToCardAction_ReturnsExpectedAction()
		{
			const string actionId = "4f3f58e33374646b5c16929a";
			var expected = new AddMemberToCardAction
			{
				Id = actionId,
				IdMemberCreator = _testUser,
				Date = new DateTime(2012, 02, 18, 07, 53, 07, 042).ToLocalTime(),
				Data = new AddMemberToCardAction.ActionData
				{
					Board = TheWelcomeBoard(),
					Card = TheLearnTricksCard(),
					IdMember = "4f2b8b464f2cb9d16d368326"
				}
			}.ToExpectedObject();

			var actual = _trelloReadOnly.Actions.WithId(actionId);

			expected.ShouldEqual(actual);
		}

		[Test]
		public void WithId_ACommentCardAction_ReturnsExpectedAction()
		{
			const string actionId = "4f3f5d073cf351b24302417d";
			var expected = new CommentCardAction
			{
				Id = actionId,
				IdMemberCreator = _testUser,
				Date = new DateTime(2012, 02, 18, 08, 10, 47, 335).ToLocalTime(),
				Data = new CommentCardAction.ActionData
				{
					Board = TheWelcomeBoard(),
					Card = new CardName
					       	{
								Id = "4f2b8b4d4f2cb9d16d3684e6",
								Name = "Welcome to Trello!"
					       	},
					Text = "A test comment"
				}
			}.ToExpectedObject();

			var actual = _trelloReadOnly.Actions.WithId(actionId);

			expected.ShouldEqual(actual);
		}

		[Test]
		public void WithId_AnAddAttachmentToCardAction_ReturnsExpectedAction()
		{
			const string actionId = "4f49c85a38b425570c18033a";
			var expected = new AddAttachmentToCardAction
			{
				Id = actionId,
				IdMemberCreator = "4f2b8b464f2cb9d16d368326",
				Date = new DateTime(2012, 02, 26, 05, 51, 22, 200).ToLocalTime(),
				Data = new AddAttachmentToCardAction.ActionData
				{
					Board = TheWelcomeBoard(),
					Card = TheWelcomeCard(),
					Attachment = new AttachmentLink
					{
					      Id = "4f49c85a38b425570c180338",
						  Name = "Penguins.jpg",
						  Url = "https://trello-attachments.s3.amazonaws.com/4f2b8b4d4f2cb9d16d3684c9/4f2b8b4d4f2cb9d16d3684e6/xsMvxPpz55JpWVqIMxENcVXKxOkx/Penguins.jpg"
			      	}
				}
			}.ToExpectedObject();

			var actual = _trelloReadOnly.Actions.WithId(actionId);

			expected.ShouldEqual(actual);
		}

		[Test]
		public void WithId_ACreateBoardAction_ReturnsExpectedAction()
		{
			const string actionId = "4f2b8b4d4f2cb9d16d3685ef";
			var expected = new CreateBoardAction
			{
				Id = actionId,
				IdMemberCreator = "4e6a7fad05d98b02ba00845c",
				Date = new DateTime(2011, 09, 09, 21, 09, 41, 515).ToLocalTime(),
				Data = new CreateBoardAction.ActionData
				{
					Board = TheWelcomeBoard()
				}
			}.ToExpectedObject();

			var actual = _trelloReadOnly.Actions.WithId(actionId);

			expected.ShouldEqual(actual);
		}

		private static CardName TheWelcomeCard()
		{
			return new CardName
			    {
			       	Id = "4f2b8b4d4f2cb9d16d3684e6",
			       	Name = "Welcome to Trello!"
			    };
		}

		private static BoardName TheWelcomeBoard()
		{
			return new BoardName
			    {
			       	Id = "4f2b8b4d4f2cb9d16d3684c9",
			       	Name = "Welcome Board"
			    };
		}

		private static CardName TheLearnTricksCard()
		{
			return new CardName
			    {
			       	Id = "4f2b8b4d4f2cb9d16d368506",
			       	Name = "To learn more tricks, check out the guide."
			    };
		}
	}
}
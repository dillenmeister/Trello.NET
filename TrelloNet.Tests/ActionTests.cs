using System;
using ExpectedObjects;
using NUnit.Framework;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class ActionTests : TrelloTestBase
	{
		private const string TestUser = "4ece5a165237e5db06624a2a";

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
				IdMemberCreator = TestUser,
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
				IdMemberCreator = TestUser,
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
				IdMemberCreator = TestUser,
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

		[Test]
		public void WithId_ACreateCardAction_ReturnsExpectedAction()
		{
			const string actionId = "4f2b9771433e15f21e004b33";
			var expected = new CreateCardAction
			{
				Id = actionId,
				IdMemberCreator = "4f2b8b464f2cb9d16d368326",
				Date = new DateTime(2012, 02, 03, 08, 14, 41, 452).ToLocalTime(),
				Data = new CreateCardAction.ActionData
				{
					Board = TheWelcomeBoard(),
					Card = new CardName
					{
						Id = "4f2b9771433e15f21e004b31",
						Name = "A closed card"
					},
					List = new ListName
					{
						Id = "4f2b8b4d4f2cb9d16d3684c1",
						Name = "Basics"
					}
				}
			}.ToExpectedObject();

			var actual = _trelloReadOnly.Actions.WithId(actionId);

			expected.ShouldEqual(actual);
		}

		[Test]
		public void WithId_AnAddMemberToBoardAction_ReturnsExpectedAction()
		{
			const string actionId = "4f359bd2655ca8cf3f047648";
			var expected = new AddMemberToBoardAction
			{
				Id = actionId,
				IdMemberCreator = TestUser,
				Date = new DateTime(2012, 02, 10, 22, 36, 02, 209).ToLocalTime(),
				Data = new AddMemberToBoardAction.ActionData
				{
					Board = TheWelcomeBoard(),
					IdMember = "4ece5a165237e5db06624a2a"
				}
			}.ToExpectedObject();

			var actual = _trelloReadOnly.Actions.WithId(actionId);

			expected.ShouldEqual(actual);
		}

		[Test]
		public void WithId_AnAddToOrganizationBoardAction_ReturnsExpectedAction()
		{
			const string actionId = "4f2b950cc1c87fcb65424143";
			var expected = new AddToOrganizationBoardAction
			{
				Id = actionId,
				IdMemberCreator = "4f2b8b464f2cb9d16d368326",
				Date = new DateTime(2012, 02, 03, 08, 04, 28, 511).ToLocalTime(),
				Data = new AddToOrganizationBoardAction.ActionData
				{
					Board = TheWelcomeBoard(),
					Organization = new OrganizationName
					               	{
					               		Id = "4f2b94c0c1c87fcb65422344",
										Name = "Trello.NET Test Organization"
					               	}
				}
			}.ToExpectedObject();

			var actual = _trelloReadOnly.Actions.WithId(actionId);

			expected.ShouldEqual(actual);
		}

		[Test]
		public void WithId_AnAddChecklistToCardAction_ReturnsExpectedAction()
		{
			const string actionId = "4f2b8b4d4f2cb9d16d3685c0";
			var expected = new AddChecklistToCardAction
			{
				Id = actionId,
				IdMemberCreator = "4e6a7fad05d98b02ba00845c",
				Date = new DateTime(2011, 09, 09, 21, 12, 14, 066).ToLocalTime(),
				Data = new AddChecklistToCardAction.ActionData
				{
					Board = TheWelcomeBoard(),
					Card = new CardName
					{
						Id = "4f2b8b4d4f2cb9d16d3684fc",
						Name = "... or checklists."
					},
					Checklist = new ChecklistName
					{
						Id = "4f2b8b4d4f2cb9d16d3684c7",
						Name = "Checklist"
					}
				}
			}.ToExpectedObject();

			var actual = _trelloReadOnly.Actions.WithId(actionId);

			expected.ShouldEqual(actual);
		}

		[Test]
		public void WithId_AnUpdateCheckItemStateOnCardAction_ReturnsExpectedAction()
		{
			const string actionId = "4f2b8b4d4f2cb9d16d3685bd";
			var expected = new UpdateCheckItemStateOnCardAction
			{
				Id = actionId,
				IdMemberCreator = "4e6a7fad05d98b02ba00845c",
				Date = new DateTime(2011, 09, 09, 21, 12, 33, 064).ToLocalTime(),
				Data = new UpdateCheckItemStateOnCardAction.ActionData
				{
					Board = TheWelcomeBoard(),
					Card = new CardName
					{
						Id = "4f2b8b4d4f2cb9d16d3684fc",
						Name = "... or checklists."
					},
					CheckItem = new CheckItemWithState
					            	{
										Id = "4f2b8b4d4f2cb9d16d3684c4",
										Name = "Make your own boards",
										State = "complete"
					            	}
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
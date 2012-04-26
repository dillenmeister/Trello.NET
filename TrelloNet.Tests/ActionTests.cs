using System;
using System.Linq;
using ExpectedObjects;
using ExpectedObjects.Strategies;
using NUnit.Framework;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class ActionTests : TrelloTestBase
	{
		private const string TrellonetTestUser = "4f2b8b464f2cb9d16d368326";
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
				Date = new DateTime(2012, 02, 18, 07, 53, 18, 696),
				Data = new RemoveMemberFromCardAction.ActionData
				{
					Board = TheWelcomeBoard(),
					Card = TheLearnTricksCard(),
					IdMember = TrellonetTestUser
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
				Date = new DateTime(2012, 02, 18, 07, 53, 07, 042),
				Data = new AddMemberToCardAction.ActionData
				{
					Board = TheWelcomeBoard(),
					Card = TheLearnTricksCard(),
					IdMember = TrellonetTestUser
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
				Date = new DateTime(2012, 02, 18, 08, 10, 47, 335),
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
				IdMemberCreator = TrellonetTestUser,
				Date = new DateTime(2012, 02, 26, 05, 51, 22, 200),
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
		public void WithId_ADeleteAttachmentFromCardAction_ReturnsExpectedAction()
		{
			const string actionId = "4f6e48d47f4c6c2b35aa45ce";
			var expected = new DeleteAttachmentFromCardAction
			{
				Id = actionId,
				IdMemberCreator = TrellonetTestUser,
				Date = new DateTime(2012, 03, 24, 22, 21, 08, 925),
				Data = new DeleteAttachmentFromCardAction.ActionData
				{
					Board = TheWelcomeBoard(),
					Card = TheWelcomeCard(),
					Attachment = new AttachmentName
					{
						Id = "4f49c85a38b425570c180338",
						Name = "Penguins.jpg"
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
				Date = new DateTime(2011, 09, 09, 21, 09, 41, 515),
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
				IdMemberCreator = TrellonetTestUser,
				Date = new DateTime(2012, 02, 03, 08, 14, 41, 452),
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
				Date = new DateTime(2012, 02, 10, 22, 36, 02, 209),
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
		public void WithId_ARemoveMemberFromBoardAction_ReturnsExpectedAction()
		{
			const string actionId = "4f71afaa9301d09b6b71b03e";
			var expected = new RemoveMemberFromBoardAction
			{
				Id = actionId,
				IdMemberCreator = TrellonetTestUser,
				Date = new DateTime(2012, 03, 27, 12, 16, 42, 272),
				Data = new RemoveMemberFromBoardAction.ActionData
				{
					Board = TheWelcomeBoard(),
					IdMember = "4f5ded65c4c07763724e6d1c"
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
				IdMemberCreator = TrellonetTestUser,
				Date = new DateTime(2012, 02, 03, 08, 04, 28, 511),
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
		public void WithId_ARemoveFromOrganizationBoardAction_ReturnsExpectedAction()
		{
			const string actionId = "4f724a4eb2cfd3503742846d";
			var expected = new RemoveFromOrganizationBoardAction
			{
				Id = actionId,
				IdMemberCreator = TrellonetTestUser,
				Date = new DateTime(2012, 03, 27, 23, 16, 30, 715),
				Data = new RemoveFromOrganizationBoardAction.ActionData
				{
					Board = new BoardName
								{
									Id = "4f724760b2cfd3503741bf2a",
									Name = "test"
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
				Date = new DateTime(2011, 09, 09, 21, 12, 14, 066),
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
		public void WithId_ARemoveChecklistFromCardAction_ReturnsExpectedAction()
		{
			const string actionId = "4f6e4f3ac962a0e45621ab14";
			var expected = new RemoveChecklistFromCardAction
			{
				Id = actionId,
				IdMemberCreator = TrellonetTestUser,
				Date = new DateTime(2012, 03, 24, 22, 48, 26, 594),
				Data = new RemoveChecklistFromCardAction.ActionData
				{
					Board = TheWelcomeBoard(),
					Card = TheWelcomeCard(),
					Checklist = new ChecklistName
					{
						Id = "4f6e4f2bc962a0e45621aa8e",
						Name = "TestCheckList"
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
				Date = new DateTime(2011, 09, 09, 21, 12, 33, 064),
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

		[Test]
		public void WithId_ACreateListAction_ReturnsExpectedAction()
		{
			const string actionId = "4f6e4fca255ed1e908575823";
			var expected = new CreateListAction
			{
				Id = actionId,
				IdMemberCreator = TrellonetTestUser,
				Date = new DateTime(2012, 03, 24, 22, 50, 50, 103),
				Data = new CreateListAction.ActionData
				{
					Board = TheWelcomeBoard(),
					List = new ListName
					{
						Id = "4f6e4fca255ed1e908575821",
						Name = "Test"
					}
				}
			}.ToExpectedObject();

			var actual = _trelloReadOnly.Actions.WithId(actionId);

			expected.ShouldEqual(actual);
		}

		[Test]
		public void WithId_ACreateOrganizationAction_ReturnsExpectedAction()
		{
			const string actionId = "4f2b94c0c1c87fcb65422346";
			var expected = new CreateOrganizationAction
			{
				Id = actionId,
				IdMemberCreator = TrellonetTestUser,
				Date = new DateTime(2012, 02, 03, 08, 03, 12, 984),
				Data = new CreateOrganizationAction.ActionData
				{
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
		public void WithId_AnUpdateBoardAction_ReturnsExpectedAction()
		{
			const string actionId = "4f2b9477c1c87fcb654209f0";

			var actual = (UpdateBoardAction)_trelloReadOnly.Actions.WithId(actionId);

			Assert.That(actual.Id, Is.EqualTo(actionId));
			Assert.That(actual.IdMemberCreator, Is.EqualTo(TrellonetTestUser));
			Assert.That(actual.Date, Is.EqualTo(new DateTime(2012, 02, 03, 08, 01, 59, 229)));
			Assert.That(actual.Data.Board.Name, Is.EqualTo("Welcome Board"));
			Assert.That(actual.Data.Board.Id, Is.EqualTo("4f2b8b4d4f2cb9d16d3684c9"));
			Assert.That((string)actual.Data.OldValue, Is.EqualTo(""));
			Assert.That((string)actual.Data.NewValue, Is.EqualTo("A test description"));
			Assert.That(actual.Data.UpdatedProperty, Is.EqualTo("desc"));
		}

		[Test]
		public void WithId_AnUpdateListAction_ReturnsExpectedAction()
		{
			const string actionId = "4f2b972e433e15f21e003fcf";

			var actual = (UpdateListAction)_trelloReadOnly.Actions.WithId(actionId);

			Assert.That(actual.Id, Is.EqualTo(actionId));
			Assert.That(actual.IdMemberCreator, Is.EqualTo(TrellonetTestUser));
			Assert.That(actual.Date, Is.EqualTo(new DateTime(2012, 02, 03, 08, 13, 34, 449)));
			Assert.That(actual.Data.Board.Name, Is.EqualTo("Welcome Board"));
			Assert.That(actual.Data.Board.Id, Is.EqualTo("4f2b8b4d4f2cb9d16d3684c9"));
			Assert.That(actual.Data.List.Name, Is.EqualTo("Basicsx"));
			Assert.That(actual.Data.List.Id, Is.EqualTo("4f2b8b4d4f2cb9d16d3684c1"));
			Assert.That((string)actual.Data.OldValue, Is.EqualTo("Basics"));
			Assert.That((string)actual.Data.NewValue, Is.EqualTo("Basicsx"));
			Assert.That(actual.Data.UpdatedProperty, Is.EqualTo("name"));
		}

		[Test]
		public void WithId_AnUpdateCardMoveAction_ReturnsExpectedAction()
		{
			const string actionId = "4f3f58c53374646b5c168e41";

			var expected = new UpdateCardMoveAction
			{
				Id = actionId,
				IdMemberCreator = "4ece5a165237e5db06624a2a",
				Date = new DateTime(2012, 02, 18, 07, 52, 37, 780),
				Data = new UpdateCardMoveAction.ActionData
				{
					Board = new BoardName
					{
						Id = "4f2b8b4d4f2cb9d16d3684c9",
						Name = "Welcome Board"
					},
					Card = new CardName
					       	{
						Id = "4f2b8b4d4f2cb9d16d3684e6",
						Name = "Welcome to Trello!"
					},
					ListBefore = new ListName
					{
						Id = "4f2b8b4d4f2cb9d16d3684c2",
						Name = "Intermediate"
					},
					ListAfter = new ListName
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
		public void WithId_AnUpdateCardAction_ReturnsExpectedAction()
		{
			const string actionId = "4f2b8b4d4f2cb9d16d368552";

			var actual = (UpdateCardAction)_trelloReadOnly.Actions.WithId(actionId);

			Assert.That(actual.Id, Is.EqualTo(actionId));
			Assert.That(actual.IdMemberCreator, Is.EqualTo("4e6a7fad05d98b02ba00845c"));
			Assert.That(actual.Date, Is.EqualTo(new DateTime(2012, 01, 09, 19, 35, 17, 719)));
			Assert.That(actual.Data.Board.Name, Is.EqualTo("Welcome Board"));
			Assert.That(actual.Data.Board.Id, Is.EqualTo("4f2b8b4d4f2cb9d16d3684c9"));
			Assert.That(actual.Data.Card.Name, Is.EqualTo("Need help?"));
			Assert.That(actual.Data.Card.Id, Is.EqualTo("4f2b8b4d4f2cb9d16d368518"));
			Assert.That((string)actual.Data.OldValue, Is.EqualTo("We got you covered: https://trello.com/help"));
			Assert.That((string)actual.Data.NewValue, Is.EqualTo("We got you covered: https://trello.com/help\n\nYou can get to the help page any time from the 'i' button in the header."));
			Assert.That(actual.Data.UpdatedProperty, Is.EqualTo("desc"));
		}

		[Test]
		public void ForBoard_TheWelcomeBoardWithPaging10_Returns10Actions()
		{
			var actions = _trelloReadOnly.Actions.ForBoard(TheWelcomeBoard(), paging: new Paging(10, 0));

			Assert.That(actions.Count(), Is.EqualTo(10));
		}

		[Test]
		public void ForBoard_TheWelcomeBoardSinceLastView_ReturnsSomething()
		{
			var actions = _trelloReadOnly.Actions.ForBoard(TheWelcomeBoard(), Since.LastView);

			Assert.That(actions, Is.Not.Null);
		}

		[Test]
		public void ForBoard_TheWelcomeBoardSinceDate_ReturnsSomething()
		{
			var actions = _trelloReadOnly.Actions.ForBoard(TheWelcomeBoard(), Since.Date(DateTime.Parse("2012-01-01")));

			Assert.That(actions.Count(), Is.GreaterThan(0));
		}

		[Test]
		public void ForCard_TheWelcomeCardWithPaging3_Returns3Actions()
		{
			var actions = _trelloReadOnly.Actions.ForCard(TheWelcomeCard(), paging: new Paging(3, 0));

			Assert.That(actions.Count(), Is.EqualTo(3));
		}

		[Test]
		public void ForList_TheBasicsListWithPaging1_Returns1Action()
		{
			var actions = _trelloReadOnly.Actions.ForList(new ListId(Constants.WelcomeBoardBasicsListId), paging: new Paging(1, 0));

			Assert.That(actions.Count(), Is.EqualTo(1));
		}

		[Test]
		public void ForOrganization_TheTestOrganizationWithPaging1_Returns1Action()
		{
			var actions = _trelloReadOnly.Actions.ForOrganization(new OrganizationId(Constants.TestOrganizationId), paging: new Paging(1, 0));

			Assert.That(actions.Count(), Is.EqualTo(1));
		}

		[Test]
		public void ForMe_WithPaging10_Returns10Actions()
		{
			var actions = _trelloReadOnly.Actions.ForMe(paging: new Paging(10, 0));

			Assert.That(actions.Count(), Is.EqualTo(10));
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

	public class TestStrategy : IComparisonStrategy
	{
		public bool CanCompare(Type type)
		{
			Console.WriteLine(type.FullName);
			return true;
		}

		public bool AreEqual(object expected, object actual, IComparisonContext comparisonContext)
		{
			Console.WriteLine(actual);
			return false;
		}
	}
}

using System;
using System.Linq;
using System.Threading.Tasks;
using ExpectedObjects;
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
				},
				MemberCreator = CreateActionMemberOskar()
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
				},
				MemberCreator = CreateActionMemberOskar(),
				Member = CreateActionMemberMe()
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
				},
				MemberCreator = CreateActionMemberOskar()
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
				},
				MemberCreator = CreateActionMemberMe()
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
				},
				MemberCreator = CreateActionMemberMe()
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
				},
				MemberCreator = CreateActionMemberTrello()
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
				},
				MemberCreator = CreateActionMemberMe()
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
				},
				MemberCreator = CreateActionMemberOskar()
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
				},
				MemberCreator = CreateActionMemberMe()
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
				},
				MemberCreator = CreateActionMemberMe()
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
				},
				MemberCreator = CreateActionMemberMe()
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
				},
				MemberCreator = CreateActionMemberTrello()
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
				},
				MemberCreator = CreateActionMemberMe()
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
				},
				MemberCreator = CreateActionMemberTrello()
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
				},
				MemberCreator = CreateActionMemberMe()
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
				},
				MemberCreator = CreateActionMemberMe()
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
            Assert.That((string)actual.Data.Old.Value, Is.EqualTo(""));
            Assert.That(actual.Data.Old.PropertyName, Is.EqualTo("desc"));
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
            Assert.That((string)actual.Data.Old.Value, Is.EqualTo("Basics"));
            Assert.That(actual.Data.Old.PropertyName, Is.EqualTo("name"));
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
				},
				MemberCreator = CreateActionMemberOskar()
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
            Assert.That((string)actual.Data.Old.Value, Is.EqualTo("We got you covered: https://trello.com/help"));
            Assert.That(actual.Data.Old.PropertyName, Is.EqualTo("desc"));
        }

        [Test]
        public void WithId_AnUpdateOrganizationAction_ReturnsExpectedAction()
        {
            const string actionId = "4f79b545f5fd74644c0d4cae";

            var actual = (UpdateOrganizationAction)_trelloReadOnly.Actions.WithId(actionId);

            Assert.That(actual.Id, Is.EqualTo(actionId));
            Assert.That(actual.IdMemberCreator, Is.EqualTo("4f2b8b464f2cb9d16d368326"));
            Assert.That(actual.Date, Is.EqualTo(new DateTime(2012, 04, 02, 14, 18, 45, 693)));
            Assert.That(actual.Data.Organization.Name, Is.EqualTo("Trello.NET Test Organization"));
            Assert.That(actual.Data.Organization.Id, Is.EqualTo("4f2b94c0c1c87fcb65422344"));
            Assert.That((string)actual.Data.Old.Value, Is.EqualTo(""));
            Assert.That(actual.Data.Old.PropertyName, Is.EqualTo("website"));
        }

        [Test]
        public void WithId_AMoveCardToBoardAction_ReturnsExpectedAction()
        {
            const string actionId = "4fb3bd28460a45151c419f2f";

            var expected = new MoveCardToBoardAction
            {
                Id = actionId,
                IdMemberCreator = "4f2b8b464f2cb9d16d368326",
                Date = new DateTime(2012, 05, 16, 14, 43, 52, 668),
                Data = new MoveCardToBoardAction.ActionData
                {
                    BoardSource = new BoardId("4f3f548a57189443042c49e1"),
                    Board = new BoardName
                    {
                        Name = "Welcome Board",
                        Id = "4f2b8b4d4f2cb9d16d3684c9"
                    },
                    Card = new CardName
                    {
                        Name = "To learn more tricks, check out the guide.",
                        Id = "4f2b8b4d4f2cb9d16d368506"
                    }
				},
				MemberCreator = CreateActionMemberMe()
            }.ToExpectedObject();

            var actual = _trelloReadOnly.Actions.WithId(actionId);

            expected.ShouldEqual(actual);
        }

        [Test]
        public void WithId_AMoveCardFromBoardAction_ReturnsExpectedAction()
        {
            const string actionId = "4fb3bd0553cd2e1031085484";

            var expected = new MoveCardFromBoardAction
            {
                Id = actionId,
                IdMemberCreator = "4f2b8b464f2cb9d16d368326",
                Date = new DateTime(2012, 05, 16, 14, 43, 17, 085),
                Data = new MoveCardFromBoardAction.ActionData
                {
                    BoardTarget = new BoardId("4f3f548a57189443042c49e1"),
                    Board = new BoardName
                    {
                        Name = "Welcome Board",
                        Id = "4f2b8b4d4f2cb9d16d3684c9"
                    },
                    Card = new CardName
                    {
                        Name = "To learn more tricks, check out the guide.",
                        Id = "4f2b8b4d4f2cb9d16d368506"
                    }
				},
				MemberCreator = CreateActionMemberMe()
            }.ToExpectedObject();

            var actual = _trelloReadOnly.Actions.WithId(actionId);

            expected.ShouldEqual(actual);
        }

        [Test]
        public void WithId_ConvertToCardFromCheckItemAction_ReturnsExpectedAction()
        {
            const string actionId = "4fb9dc4bd36927891c56115a";

            var expected = new ConvertToCardFromCheckItemAction
            {
                Id = actionId,
                IdMemberCreator = "4f2b8b464f2cb9d16d368326",
                Date = new DateTime(2012, 05, 21, 06, 10, 19, 030),
                Data = new ConvertToCardFromCheckItemAction.ActionData
                {
                    CardSource = new CardName
                    {
                        Id = "4f2b8b4d4f2cb9d16d368518",
                        Name = "Need help?"
                    },
                    Card = new CardName
                    {
                        Id = "4fb9dc4ad36927891c56107a",
                        Name = "Testing stuff"
                    },
                    Checklist = new ChecklistName
                    {
                        Id = "4fb9dc40d36927891c560dba",
                        Name = "Checklist"
                    },
                    Board = new BoardName
                    {
                        Id = "4f2b8b4d4f2cb9d16d3684c9",
                        Name = "Welcome Board"
                    },
                    CheckItem = new CheckItemName
                    {
                        Id = "4fb9dc46d36927891c560f42",
                        Name = "Testing stuff"
                    }
				},
				MemberCreator = CreateActionMemberMe()
            }.ToExpectedObject();

            var actual = _trelloReadOnly.Actions.WithId(actionId);

            expected.ShouldEqual(actual);
        }

        [Test]
        public void WithId_DeleteCardAction_ReturnsExpectedAction()
        {
            const string actionId = "5212fb1e533cf7af13000a17";
            var expected = new DeleteCardAction
            {
                Id = actionId,
                IdMemberCreator = "4f41e47ff77233e905b22bd6",
                Date = new DateTime(2013, 08, 20, 05, 14, 06, 198),
                Data = new DeleteCardAction.ActionData
                {
                    List = new ListName
                    {
                        Id = "4f41e4803374646b5c74bd61",
                        Name = "Basics"
                    },
                    Card = new CardName
                    {
                        IdShort = 302,
                        Id = "5212fb1d3d30dea523001437",
                        Name = null
                    },
                    Board = new BoardName
                    {
                        Id = "4f41e4803374646b5c74bd69",
                        Name = "Welcome Board"
                    },
                },
                MemberCreator = new Action.ActionMember
                {
                    FullName = "Trello Net",
                    Username = "usernet",
                    Id = "4f41e47ff77233e905b22bd6",
                    AvatarHash = null,
                    Initials = "TN"
                }

            }.ToExpectedObject();

            var result = _trelloReadWrite.Actions.WithId(actionId);

            var actual = result as DeleteCardAction;
            expected.ShouldEqual(actual);
        }

		[Test]
		public void WithId_CopyCardAction_ReturnsRightTypeWithValues()
		{
			const string actionId = "5284efa689cce63268004224";
			var trello = new Trello("4db5f5e3efbc86a81cf5f3633432fc64");
			trello.Authorize("bb03a75e3c7aa28fd3eceed4012f818ba094428458588532cf69e795609e6a4d");
			var expected = new CopyCardAction
			{
				Id = actionId,
				IdMemberCreator = "5284ee0726a67481680045bf",
				Date = new DateTime(2013, 11, 14, 15, 43, 34, 477),
				Data = new CopyCardAction.ActionData
				{
					CardSource = new CardName
					{
						Id = "5284ee0726a67481680045c9",
						Name = "Welcome to Trello!",
						IdShort = 1,
						ShortLink = "51YEJguq"
					},
					List = new ListName
					{
						Id = "5284ee0726a67481680045c5",
						Name = "Basics"
					},
					Card = new CardName
					{
						IdShort = 20,
						Id = "5284efa689cce63268004223",
						Name = "Welcome to Trello 2!",
						ShortLink = "I5YS0snW"
					},
					Board = new BoardName
					{
						Id = "5284ee0726a67481680045c0",
						Name = "Welcome Board",
						ShortLink = "YZZ1mDR5"
					},
				},
				MemberCreator = new Action.ActionMember
				{
					FullName = "Trello ApiGuy",
					Username = "userapiguy",
					Id = "5284ee0726a67481680045bf",
					AvatarHash = null,
					Initials = "TA"
				}

			}.ToExpectedObject();

			var result = trello.Actions.WithId(actionId);
			var actual = result as CopyCardAction;
			expected.ShouldEqual(actual);
		}

		[Test]
		public void WithId_CloseCardAction_ReturnsExpectedAction()
		{
			const string actionId = "5285c53f7bc0f5b8470085da";
			var expected = new CloseCardAction()
			{
				Id = actionId,
				IdMemberCreator = "4f41e47ff77233e905b22bd6",
				Date = new DateTime(2013, 11, 15, 06, 54, 55, 763),
				Data = new CloseCardAction.ActionData
				{
					Card = new CloseCardAction.CardName
					{
						IdShort = 1,
						ShortLink = "gPMJlZNf",
						Id = "4f41e4803374646b5c74bdb0",
						Name = "Welcome to Trello!",
						Closed = false
					},
					Board = new BoardName
					{
						Id = "4f41e4803374646b5c74bd69",
						Name = "Welcome Board",
						ShortLink = "jugcBbEa"
					},
					Old = new Old ()
				},
				MemberCreator = new Action.ActionMember
				{
					FullName = "Trello Net",
					Username = "usernet",
					Id = "4f41e47ff77233e905b22bd6",
					AvatarHash = null,
					Initials = "TN"
				}

			}.ToExpectedObject();

			var result = _trelloReadWrite.Actions.WithId(actionId);

			var actual = result as CloseCardAction;
			expected.ShouldEqual(actual);
		}


		[Test]
		public void WithId_ChangePositiondAction_ReturnsExpectedAction()
		{
			const string actionId = "5286491744bea3b55c00b33a";
			var expected = new UpdateCardPositionAction()
			{
				Id = actionId,
				IdMemberCreator = "4f41e47ff77233e905b22bd6",
				Date = new DateTime(2013, 11, 15, 16, 17, 27, 874),
				Data = new UpdateCardPositionAction.ActionData
				{
					Card = new UpdateCardPositionAction.CardName
					{
						IdShort = 15,
						ShortLink = "LE15KVKv",
						Id = "4f41e4803374646b5c74bd9b",
						Name = "Want to use keyboard shortcuts? We have them!",
						Pos = 196608
					},
					Board = new BoardName
					{
						Id = "4f41e4803374646b5c74bd69",
						Name = "Welcome Board",
						ShortLink = "jugcBbEa"
					},
					Old = new Old ()
				},
				MemberCreator = new Action.ActionMember
				{
					FullName = "Trello Net",
					Username = "usernet",
					Id = "4f41e47ff77233e905b22bd6",
					AvatarHash = null,
					Initials = "TN"
				}

			}.ToExpectedObject();

			var result = _trelloReadWrite.Actions.WithId(actionId);

			var actual = result as UpdateCardPositionAction;
			expected.ShouldEqual(actual);
		}

        [Test]
        public void ForBoard_TheWelcomeBoardWithPaging10_Returns10Actions()
        {
            var actions = _trelloReadOnly.Actions.ForBoard(TheWelcomeBoard(), paging: new Paging(10, 0));

            Assert.That(actions.Count(), Is.EqualTo(10));
        }

        [TestCase(ActionType.AddAttachmentToCard, typeof(AddAttachmentToCardAction))]
        [TestCase(ActionType.AddChecklistToCard, typeof(AddChecklistToCardAction))]
        [TestCase(ActionType.AddMemberToBoard, typeof(AddMemberToBoardAction))]
        [TestCase(ActionType.AddMemberToCard, typeof(AddMemberToCardAction))]
        [TestCase(ActionType.AddToOrganizationBoard, typeof(AddToOrganizationBoardAction))]
        [TestCase(ActionType.CommentCard, typeof(CommentCardAction))]
        [TestCase(ActionType.CreateBoard, typeof(CreateBoardAction))]
        [TestCase(ActionType.CreateCard, typeof(CreateCardAction))]
        [TestCase(ActionType.CreateList, typeof(CreateListAction))]
        [TestCase(ActionType.CreateOrganization, typeof(CreateOrganizationAction))]
        [TestCase(ActionType.RemoveChecklistFromCard, typeof(RemoveChecklistFromCardAction))]
        [TestCase(ActionType.RemoveFromOrganizationBoard, typeof(RemoveFromOrganizationBoardAction))]
        [TestCase(ActionType.RemoveMemberFromCard, typeof(RemoveMemberFromCardAction))]
        [TestCase(ActionType.UpdateBoard, typeof(UpdateBoardAction))]
        [TestCase(ActionType.UpdateCheckItemStateOnCard, typeof(UpdateCheckItemStateOnCardAction))]
        [TestCase(ActionType.UpdateOrganization, typeof(UpdateOrganizationAction))]
        [TestCase(ActionType.MoveCardToBoard, typeof(MoveCardToBoardAction))]
        [TestCase(ActionType.MoveCardFromBoard, typeof(MoveCardFromBoardAction))]
        [TestCase(ActionType.ConvertToCardFromCheckItem, typeof(ConvertToCardFromCheckItemAction))]
        public void ForBoard_TheWelcomeBoardWithFilter_ReturnsOnlyActionsOfSpecifiedType(ActionType type, Type action)
        {
            var actions = _trelloReadOnly.Actions.ForBoard(TheWelcomeBoard(), filter: new[] { type });

            Assert.That(actions, Has.All.InstanceOf(action));
        }

        [Test]
        public void ForBoard_TheWelcomeBoardSinceLastView_ReturnsSomething()
        {
            var actions = _trelloReadOnly.Actions.ForBoard(TheWelcomeBoard(), since: Since.LastView);

            Assert.That(actions, Is.Not.Null);
        }

        [Test]
        public void ForBoard_TheWelcomeBoardSinceDate_ReturnsSomething()
        {
            var actions = _trelloReadOnly.Actions.ForBoard(TheWelcomeBoard(), since: Since.Date(DateTime.Parse("2012-01-01")));

            Assert.That(actions.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void ForCard_TheWelcomeCardWithPaging3_Returns3Actions()
        {
            var actions = _trelloReadOnly.Actions.ForCard(TheWelcomeCard(), paging: new Paging(3, 0));

            Assert.That(actions.Count(), Is.EqualTo(3));
        }

        [Test]
        public void ForList_ATestList_Returns1Action()
        {
            var actions = _trelloReadOnly.Actions.ForList(new ListId("4f6e4fca255ed1e908575821"), paging: new Paging(1, 0));

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

		[Test]
		public void ForList_ATestList_Returns1ActionWithMemberCreator()
		{
			var expected = CreateActionMemberMe();

			var actions = _trelloReadOnly.Actions.ForList(new ListId("4f6e4fca255ed1e908575821"), paging: new Paging(1, 0));

			expected.ToExpectedObject().ShouldMatch(actions.First().MemberCreator);
		}

        [TestCase("this is the initial comment", "this is the updated comment")]
        public void Scenario_AddAndUpdateComment(string initialCommentText, string updatedCommentText)
        {
            //just use any card, why not create one
            var card = _trelloReadWrite.Cards.Add("My comment test card", new ListId(Constants.WritableListId));

            //add the comment
            _trelloReadWrite.Cards.AddComment(card, initialCommentText);

            //load the comment, we need its ID
            var comment =
                _trelloReadWrite.Actions.ForCard(card, new[] { ActionType.CommentCard }).Cast<CommentCardAction>().FirstOrDefault(x => x.Data.Text == initialCommentText);
            Assert.IsNotNull(comment);

            //the last-edit-date should be empty, because we haven't edited the comment yet (only created it)
            Assert.IsNull(comment.Data.DateLastEdited);

            //this sucks a little, but to make really sure that the last-edit-date is after (and not equal to) the creation-date
            System.Threading.Thread.Sleep(1000);

            //update the comment
            _trelloReadWrite.Actions.ChangeText(comment, updatedCommentText);

            //load the comment a second time, it should have the new text now
            comment = _trelloReadWrite.Actions.WithId(comment.Id) as CommentCardAction;
            Assert.IsNotNull(comment);
            Assert.That(comment.Data.Text, Is.EqualTo(updatedCommentText));

            //since the comment has been updated now, the last-edit-date should be available and greater than the creation-date
            Assert.IsNotNull(comment.Data.DateLastEdited);
            Assert.IsTrue(comment.Date < comment.Data.DateLastEdited);

            _trelloReadWrite.Cards.Delete(card);
        }

        [Test]
        public void Scenario_AddAndDeleteComment()
        {
            //just use any card, why not create one
            var card = _trelloReadWrite.Cards.Add("My comment test card", new ListId(Constants.WritableListId));
            var initialCommentsCount = card.Badges.Comments;

            //add a comment
            _trelloReadWrite.Cards.AddComment(card, "a test comment");

            //the comment count should be +1 now
            card = _trelloReadWrite.Cards.WithId(card.Id);
            Assert.That(card.Badges.Comments, Is.EqualTo(initialCommentsCount + 1));

            //delete the comment
            var action = _trelloReadWrite.Actions.ForCard(card).OrderByDescending(x => x.Date).FirstOrDefault();
            Assert.IsNotNull(action);
            _trelloReadWrite.Actions.Delete(action);

            //the comment count should be back to its initial value now
            card = _trelloReadWrite.Cards.WithId(card.Id);
            Assert.That(card.Badges.Comments, Is.EqualTo(initialCommentsCount));

            //delete the card we created before
            _trelloReadWrite.Cards.Delete(card);
        }

        [Test]
        public void ChangeText_ActionIdDoesNotExist_Throws()
        {
            Assert.That(() => _trelloReadWrite.Actions.ChangeText(GetDummyActionWithInvalidId(), "some text"),
                        Throws.InstanceOf<TrelloException>().With.Matches<TrelloException>(e => e.Message == "invalid id\n"));
        }

        [TestCase("")]
        [TestCase(null)]
        public void ChangeText_NewTextIsNullOrEmpty_Throws(string newText)
        {
            Assert.That(() => _trelloReadWrite.Actions.ChangeText(GetDummyActionWithInvalidId(), newText),
                        Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "newText"));
        }

        [Test]
        public void ChangeText_NewTextIsTooLong_Throws()
        {
            Assert.That(() => _trelloReadWrite.Actions.ChangeText(GetDummyActionWithInvalidId(), new string('x', 16385)),
                        Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "newText"));
        }

        [Test]
        public void Delete_ActionIdIsInvalid_Throws()
        {
            Assert.That(() => _trelloReadWrite.Actions.ChangeText(GetDummyActionWithInvalidId(), "some text"),
                        Throws.InstanceOf<TrelloException>().With.Matches<TrelloException>(e => e.Message == "invalid id\n"));
        }

	    [Test]
	    public void Bug_Issue33_MissingActions()
	    {
			// Create a card with a checklist and a checkitem
			var card = _trelloReadWrite.Cards.Add("Bug_Issue33 card", new ListId(Constants.WritableListId));
		    var checkList = _trelloReadWrite.Checklists.Add("Bug_Issue33 checklist", new BoardId(card.IdBoard));
			_trelloReadWrite.Cards.AddChecklist(card, checkList);
			_trelloReadWrite.Checklists.AddCheckItem(checkList, "Bug_Issue33 check item"); // TODO: Does this not return a check item id?

			// Check the check item
		    var checkItem = _trelloReadWrite.Cards.WithId(card.Id).Checklists.First().CheckItems.First();
		    _trelloReadWrite.Cards.ChangeCheckItemState(card, checkList, checkItem, true);

			// List all actions for the card
		    var actions = _trelloReadWrite.Actions.ForCard(card);

			// Clean up
			_trelloReadWrite.Cards.Delete(card);

			Assert.That(actions.OfType<UpdateCheckItemStateOnCardAction>().Any());
		}		

        private static Action GetDummyActionWithInvalidId()
        {
            return new Action
                {
                    Id = "1234"
                };
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

		private static Action.ActionMember CreateActionMemberMe()
		{
			return new Action.ActionMember
			{
				FullName = "Trello.NET Test User",
				Username = "trellnettestuser",
				Id = Constants.MeId,
				AvatarHash = "076e3caed758a1c18c91a0e9cae3368f",
				Initials = "TU"
			};
		}

		private static Action.ActionMember CreateActionMemberOskar()
		{
			return new Action.ActionMember
			{
				FullName = "Oskar Dillén",
				Username = "oskardillen",
				Id = "4ece5a165237e5db06624a2a",
				AvatarHash = "bb5dc0160e87c6573ef69c9d4a284bd2",
				Initials = "OD"
			};
		}

		private static Action.ActionMember CreateActionMemberTrello()
		{
			return new Action.ActionMember
			{
				FullName = "Trello",
				Username = "trello",
				Id = "4e6a7fad05d98b02ba00845c",
				AvatarHash = "0b71d5ac0f623c09317afa75663e374f",
				Initials = "T"
			};
		}
    }
}

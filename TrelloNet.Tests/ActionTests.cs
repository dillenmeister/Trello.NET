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
        private const string TestUser = "4f9e6801644163614d59db73";

        [Test]
        public void WithId_Null_Throws()
        {
            Assert.That(() => _trelloReadOnly.Actions.WithId(null),
                Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "actionId"));
        }

        [Test]
        public void WithId_ARemoveMemberFromCardAction_ReturnsExpectedAction()
        {
            const string actionId = "54906629873b68a7cdb49663";
            var expected = new RemoveMemberFromCardAction
            {
                Id = actionId,
                IdMemberCreator = TestUser,
                Date = new DateTime(2014, 12, 16, 17, 04, 41, 121),
                Data = new RemoveMemberFromCardAction.ActionData
                {
                    Board = TheWelcomeBoard(),
                    Card = new CardName
                    {
                        Id = "5490661c5165d3c9cdcf2e83",
                        Name = "Testing membership",
                        IdShort = 45,
                        ShortLink = "rTIw2Z1E"
                    },
                    IdMember = TestUser
				},
				MemberCreator = CreateActionMemberCDW()
            }.ToExpectedObject();

            var actual = _trelloReadOnly.Actions.WithId(actionId);

            expected.ShouldEqual(actual);
        }

        [Test]
        public void WithId_AnAddMemberToCardAction_ReturnsExpectedAction()
        {
            const string actionId = "54900fb95e34f82c5d39506f";
            var expected = new AddMemberToCardAction
            {
                Id = actionId,
                IdMemberCreator = "4f9e6801644163614d59db73",
                Date = new DateTime(2014, 12, 16, 10, 55, 53, 973),
                Data = new AddMemberToCardAction.ActionData
                {
                    Board = TheWelcomeBoard(),
                    Card = TheLearnTricksCard(),
                    IdMember = "4f9e6801644163614d59db73"				
				},
				MemberCreator = CreateActionMemberCDW(),
				Member = CreateActionMemberCDW()
            }.ToExpectedObject();

            var actual = _trelloReadOnly.Actions.WithId(actionId);

            expected.ShouldEqual(actual);
        }

        [Test]
        public void WithId_ACommentCardAction_ReturnsExpectedAction()
        {
            const string actionId = Constants.TestActionId;
            var expected = new CommentCardAction
            {
                Id = actionId,
                IdMemberCreator = TestUser,
                Date = new DateTime(2014, 12, 15, 10, 51, 43, 025),
                Data = new CommentCardAction.ActionData
                {
                    Board = TheWelcomeBoard(),
                    Card = new CardName
                    {
                        Id = Constants.WelcomeCardOfTheWelcomeBoardId,
                        Name = Constants.TestCardName1,
                        ShortLink = "21UnMVtO",
                        IdShort = 1
                    },
                    Text = "A test comment"
				},
				MemberCreator = CreateActionMemberCDW()
            }.ToExpectedObject();

            var actual = _trelloReadOnly.Actions.WithId(actionId);

            expected.ShouldEqual(actual);
        }

        [Test]
        public void WithId_AnAddAttachmentToCardAction_ReturnsExpectedAction()
        {
            const string actionId = "54901966c89082bbf3580167";
            var expected = new AddAttachmentToCardAction
            {
                Id = actionId,
                IdMemberCreator = "4f9e6801644163614d59db73",
                Date = new DateTime(2014, 12, 16, 11, 37, 10, 314),
                Data = new AddAttachmentToCardAction.ActionData
                {
                    Board = TheWelcomeBoard(),
                    Card = TheWelcomeCard(),
                    Attachment = new AttachmentLink
                    {
                        Id = "54901964c89082bbf358015e",
                        Name = "Penguins.jpg",
                    }
				},
				MemberCreator = CreateActionMemberCDW()
            }.ToExpectedObject();

            var actual = _trelloReadOnly.Actions.WithId(actionId);

            expected.ShouldEqual(actual);
        }

        [Test]
        public void WithId_ADeleteAttachmentFromCardAction_ReturnsExpectedAction()
        {
            const string actionId = "54901979f260ad67880938c0";
            var expected = new DeleteAttachmentFromCardAction
            {
                Id = actionId,
                IdMemberCreator = "4f9e6801644163614d59db73",
                Date = new DateTime(2014, 12, 16, 11, 37, 29, 395),
                Data = new DeleteAttachmentFromCardAction.ActionData
                {
                    Board = TheWelcomeBoard(),
                    Card = TheWelcomeCard(),
                    Attachment = new AttachmentName
                    {
                        Id = "54901964c89082bbf358015e",
                        Name = "Penguins.jpg"
                    }
				},
				MemberCreator = CreateActionMemberCDW()
            }.ToExpectedObject();

            var actual = _trelloReadOnly.Actions.WithId(actionId);

            expected.ShouldEqual(actual);
        }

        [Test]
        public void WithId_ACreateBoardAction_ReturnsExpectedAction()
        {
            const string actionId = "546f22e5cb8013103defe720";
            var expected = new CreateBoardAction
            {
                Id = actionId,
                IdMemberCreator = "4f9e6801644163614d59db73",
                Date = new DateTime(2014, 11, 21, 11, 32, 53, 939),
                Data = new CreateBoardAction.ActionData
                {
                    Board = TheWelcomeBoard()
				},
				MemberCreator = CreateActionMemberCDW()
			}.ToExpectedObject();

            var actual = _trelloReadOnly.Actions.WithId(actionId);

            expected.ShouldEqual(actual);
        }

        [Test]
        public void WithId_ACreateCardAction_ReturnsExpectedAction()
        {
            const string actionId = "548af14b89034704dbdb9f49";
            var expected = new CreateCardAction
            {
                Id = actionId,
                IdMemberCreator = "4f9e6801644163614d59db73",
                Date = new DateTime(2014, 12, 12, 13, 44, 43, 045),
                Data = new CreateCardAction.ActionData
                {
                    Board = TheWelcomeBoard(),
                    Card = new CardName
                    {
                        Id = "548af14b89034704dbdb9f48",
                        Name = "This card has labels",
                        IdShort = 4,
                        ShortLink = "3c7t5TNM"
                    },
                    List = new ListName
                    {
                        Id = "5489c9541410d7d4cf8622a2",
                        Name = "Advanced"
                    }
				},
				MemberCreator = CreateActionMemberCDW()
            }.ToExpectedObject();

            var actual = _trelloReadOnly.Actions.WithId(actionId);

            expected.ShouldEqual(actual);
        }

        [Test]
        public void WithId_AnAddMemberToBoardAction_ReturnsExpectedAction()
        {
            const string actionId = "546f230f872765f52bf3d939";
            var expected = new AddMemberToBoardAction
            {
                Id = actionId,
                IdMemberCreator = "4f9e6801644163614d59db73",
                Date = new DateTime(2014, 11, 21, 11, 33, 35, 100),
                Data = new AddMemberToBoardAction.ActionData
                {
                    Board = TheWelcomeBoard(),
                    IdMemberAdded = "510beb791b14e0016b008019"
				},
				MemberCreator = CreateActionMemberCDW()
            }.ToExpectedObject();

            var actual = _trelloReadOnly.Actions.WithId(actionId);

            expected.ShouldEqual(actual);
        }

        [Test, Ignore("These events are not creating actions anymore")]
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

        [Test, Ignore("These events are not creating actions anymore")]
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
            const string actionId = "5490668b52c1dc90355259da";
            var expected = new RemoveFromOrganizationBoardAction
            {
                Id = actionId,
                IdMemberCreator = TestUser,
                Date = new DateTime(2014, 12, 16, 17, 06, 19, 723),
                Data = new RemoveFromOrganizationBoardAction.ActionData
                {
                    Board = new BoardName
                    {
                        Id = "546f22e5cb8013103defe71e",
                        Name = "Trello.NET Test Board",
                        ShortLink = "UTWsO3Jc"
                    },
                    Organization = new OrganizationName
                    {
                        Id = "548b0039e035cf051fb0633d",
                        Name = "Test Organisation"
                    }
                },
                MemberCreator = CreateActionMemberCDW()
            }.ToExpectedObject();

            var actual = _trelloReadOnly.Actions.WithId(actionId);

            expected.ShouldEqual(actual);
        }

        [Test]
        public void WithId_AnAddChecklistToCardAction_ReturnsExpectedAction()
        {
            const string actionId = "5489c8f481bb7d5b780be291";
            var expected = new AddChecklistToCardAction
            {
                Id = actionId,
                IdMemberCreator = "4f9e6801644163614d59db73",
                Date = new DateTime(2014, 12, 11, 16, 40, 20, 981),
                Data = new AddChecklistToCardAction.ActionData
                {
                    Board = TheWelcomeBoard(),
                    Card = new CardName
                    {
                        Id = "5489c8eb0caf1a3c4598087b",
                        Name = "A third test card",
                        IdShort = 3,
                        ShortLink = "iAZ5wSWl"
                    },
                    Checklist = new ChecklistName
                    {
                        Id = "5489c8f481bb7d5b780be290",
                        Name = "Checklist"
                    }
				},
				MemberCreator = CreateActionMemberCDW()
            }.ToExpectedObject();

            var actual = _trelloReadOnly.Actions.WithId(actionId);

            expected.ShouldEqual(actual);
        }

        [Test]
        public void WithId_ARemoveChecklistFromCardAction_ReturnsExpectedAction()
        {
            const string actionId = "5490509f5842f766e2cf7203";
            var expected = new RemoveChecklistFromCardAction
            {
                Id = actionId,
                IdMemberCreator = "4f9e6801644163614d59db73",
                Date = new DateTime(2014, 12, 16, 15, 32, 47, 076),
                Data = new RemoveChecklistFromCardAction.ActionData
                {
                    Board = TheWelcomeBoard(),
                    Card = new CardName
                    {
                        Id = "5489c83a30bf250d785224b5",
                        Name = "Welcome to Trello!",
                        IdShort = 2,
                        ShortLink = "SyBfTUYS"
                    },
                    Checklist = new ChecklistName
                    {
                        Id = "5490509d52c1dc903552398b",
                        Name = "a test checklist"
                    }
				},
				MemberCreator = CreateActionMemberCDW()
            }.ToExpectedObject();

            var actual = _trelloReadOnly.Actions.WithId(actionId);

            expected.ShouldEqual(actual);
        }

        [Test]
        public void WithId_AnUpdateCheckItemStateOnCardAction_ReturnsExpectedAction()
        {
            const string actionId = "5489c910dd356581ed12f5b1";
            var expected = new UpdateCheckItemStateOnCardAction
            {
                Id = actionId,
                IdMemberCreator = "4f9e6801644163614d59db73",
                Date = new DateTime(2014, 12, 11, 16, 40, 48, 921),
                Data = new UpdateCheckItemStateOnCardAction.ActionData
                {
                    Board = TheWelcomeBoard(),
                    Card = new CardName
                    {
                        Id = "5489c8eb0caf1a3c4598087b",
                        Name = "A third test card",
                        IdShort = 3,
                        ShortLink = "iAZ5wSWl"
                    },
                    CheckItem = new CheckItemWithState
                                    {
                                        Id = "5489c8fd46994a811b89fdbc",
                                        Name = "Make your own board",
                                        State = "complete"
                                    }
				},
				MemberCreator = CreateActionMemberCDW()
            }.ToExpectedObject();

            var actual = _trelloReadOnly.Actions.WithId(actionId);

            expected.ShouldEqual(actual);
        }

        [Test]
        public void WithId_ACreateListAction_ReturnsExpectedAction()
        {
            const string actionId = "5489c9541410d7d4cf8622a3";
            var expected = new CreateListAction
            {
                Id = actionId,
                IdMemberCreator = "4f9e6801644163614d59db73",
                Date = new DateTime(2014, 12, 11, 16, 41, 56, 737),
                Data = new CreateListAction.ActionData
                {
                    Board = TheWelcomeBoard(),
                    List = new ListName
                    {
                        Id = "5489c9541410d7d4cf8622a2",
                        Name = "Advanced"
                    }
				},
				MemberCreator = CreateActionMemberCDW()
            }.ToExpectedObject();

            var actual = _trelloReadOnly.Actions.WithId(actionId);

            expected.ShouldEqual(actual);
        }

        [Test, Ignore("These events are not creating actions anymore")]
        public void WithId_ACreateOrganizationAction_ReturnsExpectedAction()
        {
            const string actionId = "4f2b94c0c1c87fcb65422346";
            var expected = new CreateOrganizationAction
            {
                Id = actionId,
                IdMemberCreator = "4f9e6801644163614d59db73",
                Date = new DateTime(2012, 02, 03, 08, 03, 12, 984),
                Data = new CreateOrganizationAction.ActionData
                {
                    Organization = new OrganizationName
                    {
                        Id = "4f2b94c0c1c87fcb65422344",
                        Name = "Trello.NET Test Organization"
                    }
				},
				MemberCreator = CreateActionMemberCDW()
            }.ToExpectedObject();

            var actual = _trelloReadOnly.Actions.WithId(actionId);

            expected.ShouldEqual(actual);
        }

        [Test]
        public void WithId_AnUpdateBoardAction_ReturnsExpectedAction()
        {
            const string actionId = "549054ed5842f766e2cf776d";

            var actual = (UpdateBoardAction)_trelloReadOnly.Actions.WithId(actionId);

            Assert.That(actual.Id, Is.EqualTo(actionId));
            Assert.That(actual.IdMemberCreator, Is.EqualTo(TestUser));
            Assert.That(actual.Date, Is.EqualTo(new DateTime(2014, 12, 16, 15, 51, 09, 832)));
            Assert.That(actual.Data.Board.Name, Is.EqualTo(Constants.TestBoardName));
            Assert.That(actual.Data.Board.Id, Is.EqualTo("546f22e5cb8013103defe71e"));
            Assert.That((string)actual.Data.Old.Value, Is.EqualTo("True"));
            Assert.That(actual.Data.Old.PropertyName, Is.EqualTo("closed"));
        }

        [Test]
        public void WithId_AnUpdateListAction_ReturnsExpectedAction()
        {
            const string actionId = "549050b23bcfa906ebb51736";

            var actual = (UpdateListAction)_trelloReadOnly.Actions.WithId(actionId);

            Assert.That(actual.Id, Is.EqualTo(actionId));
            Assert.That(actual.IdMemberCreator, Is.EqualTo("4f9e6801644163614d59db73"));
            Assert.That(actual.Date, Is.EqualTo(new DateTime(2014, 12, 16, 15, 33, 06, 260)));
            Assert.That(actual.Data.Board.Name, Is.EqualTo(Constants.TestBoardName));
            Assert.That(actual.Data.Board.Id, Is.EqualTo(Constants.WelcomeBoardId));
            Assert.That(actual.Data.List.Name, Is.EqualTo("Basics"));
            Assert.That(actual.Data.List.Id, Is.EqualTo("546f22eea6c3d57a9c63d1b6"));
            Assert.That((string)actual.Data.Old.Value, Is.EqualTo("Updated name"));
            Assert.That(actual.Data.Old.PropertyName, Is.EqualTo("name"));
        }

        [Test]
        public void WithId_AnUpdateCardMoveAction_ReturnsExpectedAction()
        {
            const string actionId = "54901d9a9ce6202e30717def";

            var expected = new UpdateCardMoveAction
            {
                Id = actionId,
                IdMemberCreator = "4f9e6801644163614d59db73",
                Date = new DateTime(2014, 12, 16, 11, 55, 06, 569),
                Data = new UpdateCardMoveAction.ActionData
                {
                    Board = new BoardName
                    {
                        Id = Constants.WelcomeBoardId,
                        Name = Constants.TestBoardName,
                        ShortLink = "UTWsO3Jc"
                    },
                    Card = new CardName
                            {
                                Id = "54901d97acb992f4f3c25127",
                                Name = "This card has moved",
                                IdShort = 27,
                                ShortLink = "QQeTBWMy",
                            },
                    ListBefore = new ListName
                    {
                        Id = "546f22eea6c3d57a9c63d1b6",
                        Name = "Basics"
                    },
                    ListAfter = new ListName
                    {
                        Id = "546f22f06bee6baf018b541d",
                        Name = "Intermediate"
                    }
				},
				MemberCreator = CreateActionMemberCDW()
            }.ToExpectedObject();

            var actual = _trelloReadOnly.Actions.WithId(actionId);

            expected.ShouldEqual(actual);
        }

        [Test]
        public void WithId_AnUpdateCardAction_ReturnsExpectedAction()
        {
            const string actionId = "549050a3c6ec0e171342e5c5";

            var actual = (UpdateCardAction)_trelloReadOnly.Actions.WithId(actionId);

            Assert.That(actual.Id, Is.EqualTo(actionId));
            Assert.That(actual.IdMemberCreator, Is.EqualTo("4f9e6801644163614d59db73"));
            Assert.That(actual.Date, Is.EqualTo(new DateTime(2014, 12, 16, 15, 32, 51, 332)));
            Assert.That(actual.Data.Board.Name, Is.EqualTo(Constants.TestBoardName));
            Assert.That(actual.Data.Board.Id, Is.EqualTo("546f22e5cb8013103defe71e"));
            Assert.That(actual.Data.Card.Name, Is.EqualTo("Welcome to Trello!"));
            Assert.That(actual.Data.Card.Id, Is.EqualTo("5489c83a30bf250d785224b5"));
            Assert.That((string)actual.Data.Old.Value, Is.EqualTo("A new name"));
            Assert.That(actual.Data.Old.PropertyName, Is.EqualTo("name"));
        }

        [Test, Ignore("These events are not creating actions anymore")]
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
            const string actionId = "54901f357dd09e434f0dcda3";

            var expected = new MoveCardToBoardAction
            {
                Id = actionId,
                IdMemberCreator = "4f9e6801644163614d59db73",
                Date = new DateTime(2014, 12, 16, 12, 01, 57, 964),
                Data = new MoveCardToBoardAction.ActionData
                {
                    BoardSource = new BoardId("546f22e5cb8013103defe71e"),
                    Board = new BoardName
                    {
                        Name = "Welcome Board",
                        Id = "4f9e6802644163614d59db7f",
                        ShortLink = "vsP00mMP"
                    },
                    Card = new CardName
                    {
                        Name = "This card has moved board",
                        Id = "54901f1c8e296a00309e4141",
                        IdShort = 20,
                        ShortLink = "k4xxhAwj"
                    },
                    List = new ListName
                    {
                        Name = "Advanced",
                        Id = "4f9e6802644163614d59db87"
                    }
                },
                MemberCreator = CreateActionMemberCDW()
            }.ToExpectedObject();

            var actual = _trelloReadOnly.Actions.WithId(actionId);

            expected.ShouldEqual(actual);
        }
		
		[Test]
        public void WithId_AMoveCardFromBoardAction_ReturnsExpectedAction()
        {
            const string actionId = "54901f357dd09e434f0dcda2";

            var expected = new MoveCardFromBoardAction
            {
                Id = actionId,
                IdMemberCreator = "4f9e6801644163614d59db73",
                Date = new DateTime(2014, 12, 16, 12, 01, 57, 963),
                Data = new MoveCardFromBoardAction.ActionData
                {
                    BoardTarget = new BoardId("4f9e6802644163614d59db7f"),
                    Board = new BoardName
                    {
                        Name = Constants.TestBoardName,
                        Id = Constants.WelcomeBoardId,
                        ShortLink = "UTWsO3Jc"
                    },
                    Card = new CardName
                    {
                        Name = "This card has moved board",
                        Id = "54901f1c8e296a00309e4141"
                    }
				},
				MemberCreator = CreateActionMemberCDW()
            }.ToExpectedObject();

            var actual = _trelloReadOnly.Actions.WithId(actionId);

            expected.ShouldEqual(actual);
        }

        [Test]
        public void WithId_ConvertToCardFromCheckItemAction_ReturnsExpectedAction()
        {
            const string actionId = "54906660432f718207a69caa";

            var expected = new ConvertToCardFromCheckItemAction
            {
                Id = actionId,
                IdMemberCreator = "4f9e6801644163614d59db73",
                Date = new DateTime(2014, 12, 16, 17, 05, 36, 471),
                Data = new ConvertToCardFromCheckItemAction.ActionData
                {
                    CardSource = new CardName
                    {
                        Id = "5490661c5165d3c9cdcf2e83",
                        Name = "Testing membership",
                        ShortLink = "rTIw2Z1E",
                        IdShort = 45
                    },
                    Card = new CardName
                    {
                        Id = "54906660432f718207a69ca9",
                        Name = "Convert this item to a card",
                        IdShort = 46
                    },
                    Board = new BoardName
                    {
                        Id = "546f22e5cb8013103defe71e",
                        Name = Constants.TestBoardName,
                        ShortLink = "UTWsO3Jc"
                    },
                    List = new ListName
                    {
                        Id = "5489c9541410d7d4cf8622a2",
                        Name = "Advanced"
                    }
                },
                MemberCreator = CreateActionMemberCDW()
            }.ToExpectedObject();

            var actual = _trelloReadOnly.Actions.WithId(actionId);

            expected.ShouldEqual(actual);
        }

        [Test]
        public void WithId_DeleteCardAction_ReturnsExpectedAction()
        {
            const string actionId = "54905dc1db0fa4f6f37fca72";
            var expected = new DeleteCardAction
            {
                Id = actionId,
                IdMemberCreator = "4f9e6801644163614d59db73",
                Date = new DateTime(2014, 12, 16, 16, 28, 49, 650),
                Data = new DeleteCardAction.ActionData
                {
                    List = new ListName
                    {
                        Id = "546f22eea6c3d57a9c63d1b6",
                        Name = "Basics"
                    },
                    Card = new CardName
                    {
                        IdShort = 44,
                        Id = "54905dbf2770886a88190785",
                        Name = null
                    },
                    Board = new BoardName
                    {
                        Id = "546f22e5cb8013103defe71e",
                        Name = Constants.TestBoardName,
                        ShortLink = "UTWsO3Jc"
                    },
                },
                MemberCreator = CreateActionMemberCDW()

            }.ToExpectedObject();

            var result = _trelloReadWrite.Actions.WithId(actionId);

            var actual = result as DeleteCardAction;
            expected.ShouldEqual(actual);
        }		

		[Test]
		public void WithId_CloseCardAction_ReturnsExpectedAction()
		{
            const string actionId = "549066c5cde2c78335813daa";
			var expected = new CloseCardAction()
			{
				Id = actionId,
                IdMemberCreator = "4f9e6801644163614d59db73",
				Date = new DateTime(2014, 12, 16, 17, 07, 17, 326),
				Data = new CloseCardAction.ActionData
				{
					Card = new CloseCardAction.CardName
					{
						IdShort = 47,
                        ShortLink = "8JomUKyL",
                        Id = "549066bea79849355dc793c8",
                        Name = "This card will be closed",
						Closed = true
					},
					Board = new BoardName
					{
						Id = Constants.WelcomeBoardId,
                        Name = Constants.TestBoardName,
                        ShortLink = "UTWsO3Jc"
					},
					Old = new Old ()
				},
				MemberCreator = CreateActionMemberCDW()

			}.ToExpectedObject();

			var result = _trelloReadWrite.Actions.WithId(actionId);

			var actual = result as CloseCardAction;
			expected.ShouldEqual(actual);
		}


		[Test]
		public void WithId_ChangePositionAction_ReturnsExpectedAction()
		{
            const string actionId = "5492e001db393d0dea45fb0f";
            var expected = new UpdateCardPositionAction()
            {
                Id = actionId,
                IdMemberCreator = "4f9e6801644163614d59db73",
                Date = new DateTime(2014, 12, 18, 14, 09, 05, 695),
                Data = new UpdateCardPositionAction.ActionData
                {
                    Card = new UpdateCardPositionAction.CardName
                    {
                        IdShort = 46,
                        ShortLink = "yFzlMyML",
                        Id = "54906660432f718207a69ca9",
                        Name = "Convert this item to a card",
                        Pos = 16383.75
                    },
                    Board = new BoardName
                    {
                        Id = Constants.WelcomeBoardId,
                        Name = Constants.TestBoardName,
                        ShortLink = "UTWsO3Jc"
                    },
                    Old = new Old()
                },
                MemberCreator = CreateActionMemberCDW()

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

		[Test]
		public void ForList_ATestList_Returns1ActionWithMemberCreator()
		{
			var expected = CreateActionMemberCDW();

			var actions = _trelloReadOnly.Actions.ForList(new ListId(Constants.WelcomeBoardBasicsListId), paging: new Paging(1, 0));

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
                    Id = Constants.WelcomeCardOfTheWelcomeBoardId,
                    Name = Constants.TestCardName1,
                    IdShort = 1,
                    ShortLink = "21UnMVtO"
                };
        }

        private static BoardName TheWelcomeBoard()
        {
            return new BoardName
                {
                    Id = Constants.WelcomeBoardId,
                    Name = Constants.TestBoardName,
                    ShortLink = "UTWsO3Jc"
                };
        }

        private static CardName TheLearnTricksCard()
        {
            return new CardName
                {
                    Id = Constants.TestCardId2,
                    Name = Constants.TestCardName2,
                    IdShort = 2,
                    ShortLink = "SyBfTUYS"
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

        private static Action.ActionMember CreateActionMemberCDW()
        {
            return new Action.ActionMember
            {
                FullName = "Christopher Downes-Ward",
                Username = "christopherdownesward",
                Id = "4f9e6801644163614d59db73",
                AvatarHash = "5db13c831c6f50ac6e97217bc77f4034",
                Initials = "CDW"
            };
        }

		private static Action.ActionMember CreateActionMemberTrello()
		{
			return new Action.ActionMember
			{
				FullName = "Trello",
				Username = "trello",
				Id = "4e6a7fad05d98b02ba00845c",
                AvatarHash = "a6cc37f6849928acb91064cf65e61cbc",
				Initials = "T"
			};
		}
    }
}

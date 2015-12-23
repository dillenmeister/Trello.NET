using System;
using System.Collections.Generic;
using System.Linq;
using ExpectedObjects;
using NUnit.Framework;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class BoardTests : TrelloTestBase
	{
		private readonly IBoardId _welcomeBoardWritable = new BoardId(Constants.WelcomeBoardId);

		[Test]
		public void WithId_TheWelcomeBoard_ReturnsExpectedWelcomeBoard()
		{
			var expectedBoard = CreateExpectedWelcomeBoard();

			var actualBoard = _trelloReadOnly.Boards.WithId(Constants.WelcomeBoardId);

			expectedBoard.ShouldMatch(actualBoard);
			Assert.That(actualBoard.LabelNames, Is.EquivalentTo(CreateExpectedWelcomeBoardLabels()));
		}

		[Test]
		public void WithId_AClosedBoard_ClosedIsTrue()
		{
			var board = _trelloReadOnly.Boards.WithId(Constants.AClosedBoardId);

			Assert.That(board.Closed, Is.True);
		}

		[Test]
		public void WithId_AnUnpinnedBoard_PinnedIsFalse()
		{
			var board = _trelloReadOnly.Boards.WithId(Constants.AnUnpinnedBoard);

			Assert.That(board.Pinned, Is.False);
		}

        // Ok, don't know if "owners" is replaced by "admins" in Prefs.Invitations. Let's keep both in the enum.
		[Test]
		public void WithId_ABoardWithInvitationPermissionSetToAdmins_InvitationPermissionIsAdmins()
		{
			var board = _trelloReadOnly.Boards.WithId(Constants.ABoardWithInvitationPermissionSetToOwnerId);

			Assert.That(board.Prefs.Invitations, Is.EqualTo(InvitationPermission.Admins));
		}

		[Test]
		public void WithId_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Boards.WithId(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "id"));
		}

		[Test]
		public void ForMember_Me_ReturnsTheWelcomeBoard()
		{
			var boards = _trelloReadOnly.Boards.ForMember(new Me());

            Assert.That(boards, Has.Some.Matches<Board>(b => b.Name == Constants.TestBoardName));
		}

		[Test]
		public void ForMe_Always_ReturnsTheWelcomeBoard()
		{
			var boards = _trelloReadOnly.Boards.ForMe();

            Assert.That(boards, Has.Some.Matches<Board>(b => b.Name == Constants.TestBoardName));
		}

		[Test]
		public void ForMember_Me_AllFieldsOfBoardAreMapped()
		{
			var expectedBoard = CreateExpectedWelcomeBoard();

			var actualBoard = _trelloReadOnly.Boards.ForMember(new Me()).Single(b => b.Id == Constants.WelcomeBoardId);

			expectedBoard.ShouldMatch(actualBoard);
			Assert.That(actualBoard.LabelNames, Is.EquivalentTo(CreateExpectedWelcomeBoardLabels()));
		}

		[Test]
		public void ForMember_MeAndClosed_ReturnsTheClosedBoard()
		{
			var boards = _trelloReadOnly.Boards.ForMember(new Me(), BoardFilter.Closed);

            // I have multiple boards and regularly close them...
			Assert.That(boards, Has.Count.GreaterThan(2));
            Assert.That(boards, Has.Some.Matches<Board>(b => b.Name == "Trello.NET Test Board"));
		}

		[Test]
		public void ForMember_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Boards.ForMember(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "member"));
		}

		[Test]
		public void ForCard_TheWelcomeCard_ReturnsTheWelcomeBoard()
		{
			var expectedBoard = CreateExpectedWelcomeBoard();

			var board = _trelloReadOnly.Boards.ForCard(new CardId(Constants.WelcomeCardOfTheWelcomeBoardId));

			expectedBoard.ShouldMatch(board);
			Assert.That(board.LabelNames, Is.EquivalentTo(CreateExpectedWelcomeBoardLabels()));
		}

		[Test]
		public void ForCard_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Boards.ForCard(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "card"));
		}

		[Test]
		public void ForChecklist_TheChecklistInTheLastCardOfTheBasicsList_ReturnsTheWelcomeBoard()
		{
			var expectedBoard = CreateExpectedWelcomeBoard();

			var board = _trelloReadOnly.Boards.ForChecklist(new ChecklistId(Constants.ChecklistId));

			expectedBoard.ShouldMatch(board);
			Assert.That(board.LabelNames, Is.EquivalentTo(CreateExpectedWelcomeBoardLabels()));
		}

		[Test]
		public void ForChecklist_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Boards.ForChecklist(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "checklist"));
		}

		[Test]
		public void ForList_TheWelcomeBoardBasicsList_ReturnsTheWelcomeBoard()
		{
			var expectedBoard = CreateExpectedWelcomeBoard();

			var board = _trelloReadOnly.Boards.ForList(new ListId(Constants.WelcomeBoardBasicsListId));

			expectedBoard.ShouldMatch(board);
			Assert.That(board.LabelNames, Is.EquivalentTo(CreateExpectedWelcomeBoardLabels()));
		}

		[Test]
		public void ForList_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Boards.ForList(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "list"));
		}

		[Test]
		public void ForOrganization_TestOrganization_ReturnsTheWelcomeBoard()
		{
			var expectedBoard = CreateExpectedWelcomeBoard();

			var boards = _trelloReadOnly.Boards.ForOrganization(new OrganizationId(Constants.TestOrganizationId));

			Assert.That(boards.Count(), Is.EqualTo(3));
            foreach(var b in boards) {
                if (b.Name.StartsWith("Trello"))
                {
                    expectedBoard.ShouldMatch(b);
                    Assert.That(b.LabelNames, Is.EquivalentTo(CreateExpectedWelcomeBoardLabels()));
                }
            }
		}

		[Test]
		public void ForOrganization_TestOrganizationAndClosed_ReturnsNoBoards()
		{
			var boards = _trelloReadOnly.Boards.ForOrganization(new OrganizationId(Constants.TestOrganizationId), BoardFilter.Closed);

			Assert.That(boards.Count(), Is.EqualTo(1));
		}

		[Test]
		public void ForOrganization_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Boards.ForOrganization(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "organization"));
		}

		[Test]
		public void Scenario_AddAndClose()
		{
			var newBoard = _trelloReadWrite.Boards.Add(new NewBoard("A new board") { Desc = "the description" });

			Assert.That(newBoard, Is.Not.Null);
			Assert.That(newBoard.Name, Is.EqualTo("A new board"));

			_trelloReadWrite.Boards.Close(newBoard);

			var closedBoard = _trelloReadWrite.Boards.WithId(newBoard.Id);

			Assert.That(closedBoard.Closed, Is.True);
		}

		[Test]
		public void Scenario_CloseAndReOpen()
		{
			_trelloReadWrite.Boards.Close(_welcomeBoardWritable);

			var closedBoard = _trelloReadWrite.Boards.WithId(_welcomeBoardWritable.GetBoardId());
			Assert.That(closedBoard.Closed, Is.True);

			_trelloReadWrite.Boards.ReOpen(closedBoard);

			var reopenedBoard = _trelloReadWrite.Boards.WithId(_welcomeBoardWritable.GetBoardId());

			Assert.That(reopenedBoard.Closed, Is.False);
		}

		[Test]
		public void Scenario_ChangeName()
		{
			_trelloReadWrite.Boards.ChangeName(_welcomeBoardWritable, "A new name");

			var boardwithChangedName = _trelloReadWrite.Boards.WithId(_welcomeBoardWritable.GetBoardId());

			Assert.That(boardwithChangedName.Name, Is.EqualTo("A new name"));

			_trelloReadWrite.Boards.ChangeName(_welcomeBoardWritable, Constants.TestBoardName);
		}

		[Test]
		public void Scenario_UpdateNameDescriptionAndClosed()
		{
            var board = _trelloReadWrite.Boards.WithId(Constants.AClosedBoardId);

			board.Name = "Updated name";
			board.Closed = false;

			_trelloReadWrite.Boards.Update(board);

			var boardAfterUpdate = _trelloReadWrite.Boards.WithId(board.Id);

			board.Name = Constants.TestBoardName;
			board.Closed = true;

			_trelloReadWrite.Boards.Update(board);

			Assert.That(boardAfterUpdate.Name, Is.EqualTo("Updated name"));
			Assert.That(boardAfterUpdate.Closed, Is.EqualTo(false));
		}

		[Test]
		public void Scenario_ChangePermissionLevel()
		{
			_trelloReadWrite.Boards.ChangePermissionLevel(_welcomeBoardWritable, PermissionLevel.Public);
			var boardAfterUpdate = _trelloReadWrite.Boards.WithId(_welcomeBoardWritable.GetBoardId());
			_trelloReadWrite.Boards.ChangePermissionLevel(_welcomeBoardWritable, PermissionLevel.Private);

			Assert.That(boardAfterUpdate.Prefs.PermissionLevel, Is.EqualTo(PermissionLevel.Public));
		}

		[Test]
        public void Scenario_AddAndRemoveMember()
        {
	        var member = new MemberId(Constants.DevelopmentId);

	        _trelloReadWrite.Boards.AddMember(_welcomeBoardWritable, member);
            var membersAfterAddMember = _trelloReadWrite.Members.ForBoard(_welcomeBoardWritable);

            _trelloReadWrite.Boards.RemoveMember(_welcomeBoardWritable, member);
			var membersAfterRemoveMember = _trelloReadWrite.Members.ForBoard(_welcomeBoardWritable);

            Assert.That(membersAfterAddMember.Any(x => x.Id.Equals(Constants.DevelopmentId)));
            Assert.That(!membersAfterRemoveMember.Any(x => x.Id.Equals(Constants.DevelopmentId)));
        }

		[Test]
		public void Scenario_ChangeLabelName()
		{
			var board = _welcomeBoardWritable;
			_trelloReadWrite.Boards.ChangeLabelName(board, "red", "Bug");

			var boardAfterChange = _trelloReadWrite.Boards.WithId(board.GetBoardId());
			_trelloReadWrite.Boards.ChangeLabelName(board, "red", null);

			Assert.That(boardAfterChange.LabelNames["red"], Is.EqualTo("Bug"));
		}

		[Test]
		public void ToString_EqualsName()
		{
			var board = new Board { Name = "a name" };

			Assert.That(board.ToString(), Is.EqualTo("a name"));
		}

		[TestCase("")]
		[TestCase(null)]
		public void Add_NameIsInvalid_Throws(string boardName)
		{
			Assert.That(() => _trelloReadWrite.Boards.Add(new NewBoard(boardName)),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "name"));
		}

		[Test]
		public void Add_DescriptionIsTooLong_Throws()
		{
			Assert.That(() => _trelloReadWrite.Boards.Add(new NewBoard("dummy") { Desc = new string('x', 16385) }),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "desc"));
		}

		[TestCase("")]
		[TestCase(null)]
		public void AddOverload_NameIsInvalid_Throws(string boardName)
		{
			Assert.That(() => _trelloReadWrite.Boards.Add(boardName),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "name"));
		}

		[Test]
		public void Add_NameIsTooLong_Throws()
		{
			Assert.That(() => _trelloReadWrite.Boards.Add(new NewBoard(new string('x', 16385))),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "name"));
		}

		[TestCase("")]
		[TestCase(null)]
		public void ChangeName_NameIsInvalid_Throws(string boardName)
		{
			Assert.That(() => _trelloReadWrite.Boards.ChangeName(new BoardId("dummy"), boardName),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "name"));
		}

		[Test]
		public void ChangeName_NameIsTooLong_Throws()
		{
			Assert.That(() => _trelloReadWrite.Boards.ChangeName(new BoardId("dummy"), new string('x', 16385)),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "name"));
		}

		[Test]
		public void ChangeDescription_DescriptionIsTooLong_Throws()
		{
			Assert.That(() => _trelloReadWrite.Boards.ChangeDescription(new BoardId("dummy"), new string('x', 16385)),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "desc"));
		}

        [Test]
	    public void Bug_Issue38_CantReadPublicBoardWithoutAuthentication()
	    {
            _trelloReadOnly.Deauthorize();
            var board = _trelloReadOnly.Boards.WithId("d6EXlALH");

            Assert.That(board.Id, Is.EqualTo("5249174dc46a77795e002728"));
            Assert.That(board.Name, Is.EqualTo("Public Board"));
	    }

		private static ExpectedObject CreateExpectedWelcomeBoard()
		{
			return new
			{
				Closed = false,
                Name = Constants.TestBoardName,
				IdOrganization = Constants.TestOrganizationId,
                Pinned = false,
				Starred = true,
                Url = "https://trello.com/b/UTWsO3Jc/trello-net-test-board",
				Id = Constants.WelcomeBoardId,
				Prefs = new BoardPreferences
				{
					Comments = CommentPermission.Members,
					Invitations = InvitationPermission.Members,
					PermissionLevel = PermissionLevel.Private,
					Voting = VotingPermission.Members
				}
			}.ToExpectedObject();
		}

		private static Dictionary<String, string> CreateExpectedWelcomeBoardLabels()
		{
			return new Dictionary<String, string>
				{
					{ "yellow", "I am yellow" },
					{ "red", "Bug" },
					{ "purple", "I am purple" },
					{ "orange", "I am amber" },
					{ "green", "I am green" },
					{ "blue", "I am blue" },
                    { "sky", "" },
                    { "lime", "" },
                    { "pink", "" },
                    { "black", "" }
				};
		}

        private static Dictionary<String, string> CreateExpectedWelcomeBoardLabelsWithNoNames()
        {
            return new Dictionary<String, string>
				{
					{ "yellow", "" },
					{ "red", "" },
					{ "purple", "" },
					{ "orange", "" },
					{ "green", "" },
					{ "blue", "" },
                    { "sky", "" },
                    { "lime", "" },
                    { "pink", "" },
                    { "black", "" }
				};
        }
	}
}
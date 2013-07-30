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
		private readonly IBoardId _welcomeBoardWritable = new BoardId("4f41e4803374646b5c74bd69");

		[Test]
		public void WithId_TheWelcomeBoard_ReturnsExpectedWelcomeBoard()
		{
			var expectedBoard = CreateExpectedWelcomeBoard();

			var actualBoard = _trelloReadOnly.Boards.WithId(Constants.WelcomeBoardId);

			expectedBoard.ShouldEqual(actualBoard);
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

			Assert.That(boards, Has.Some.Matches<Board>(b => b.Name == "Welcome Board"));
		}

		[Test]
		public void ForMe_Always_ReturnsTheWelcomeBoard()
		{
			var boards = _trelloReadOnly.Boards.ForMe();

			Assert.That(boards, Has.Some.Matches<Board>(b => b.Name == "Welcome Board"));
		}

		[Test]
		public void ForMember_Me_AllFieldsOfBoardAreMapped()
		{
			var expectedBoard = CreateExpectedWelcomeBoard();

			var actualBoard = _trelloReadOnly.Boards.ForMember(new Me()).Single(b => b.Id == Constants.WelcomeBoardId);

			expectedBoard.ShouldEqual(actualBoard);
		}

		[Test]
		public void ForMember_MeAndClosed_ReturnsTheClosedBoard()
		{
			var boards = _trelloReadOnly.Boards.ForMember(new Me(), BoardFilter.Closed);

			Assert.That(boards, Has.Count.EqualTo(2));
			Assert.That(boards, Has.Some.Matches<Board>(b => b.Name == "A closed board"));
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

			expectedBoard.ShouldEqual(board);
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

			var board = _trelloReadOnly.Boards.ForChecklist(new ChecklistId("4f2b8b4d4f2cb9d16d3684c7"));

			expectedBoard.ShouldEqual(board);
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

			expectedBoard.ShouldEqual(board);
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

			Assert.That(boards.Count(), Is.EqualTo(1));
			expectedBoard.ShouldEqual(boards.First());
		}

		[Test]
		public void ForOrganization_TestOrganizationAndClosed_ReturnsNoBoards()
		{
			var boards = _trelloReadOnly.Boards.ForOrganization(new OrganizationId(Constants.TestOrganizationId), BoardFilter.Closed);

			Assert.That(boards.Count(), Is.EqualTo(0));
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
			Assert.That(newBoard.Desc, Is.EqualTo("the description"));

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

			_trelloReadWrite.Boards.ChangeName(_welcomeBoardWritable, "Welcome Board");
		}

		[Test]
		public void Scenario_ChangeDescription()
		{			
			_trelloReadWrite.Boards.ChangeDescription(_welcomeBoardWritable, "A new description");

			var boardwithChangedDescription = _trelloReadWrite.Boards.WithId(_welcomeBoardWritable.GetBoardId());

			Assert.That(boardwithChangedDescription.Desc, Is.EqualTo("A new description"));

			_trelloReadWrite.Boards.ChangeDescription(_welcomeBoardWritable, "");
		}

		[Test]
		public void Scenario_UpdateNameDescriptionAndClosed()
		{
			var board = _trelloReadWrite.Boards.WithId("4f41e4803374646b5c74bd69");

			board.Name = "Updated name";
			board.Desc = "Updated description";
			board.Closed = true;

			_trelloReadWrite.Boards.Update(board);

			var boardAfterUpdate = _trelloReadWrite.Boards.WithId(board.Id);

			board.Name = "Welcome Board";
			board.Desc = "";
			board.Closed = false;

			_trelloReadWrite.Boards.Update(board);

			Assert.That(boardAfterUpdate.Name, Is.EqualTo("Updated name"));
			Assert.That(boardAfterUpdate.Desc, Is.EqualTo("Updated description"));
			Assert.That(boardAfterUpdate.Closed, Is.EqualTo(true));
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
	        var member = new MemberId(Constants.MeId);

	        _trelloReadWrite.Boards.AddMember(_welcomeBoardWritable, member);
            var membersAfterAddMember = _trelloReadWrite.Members.ForBoard(_welcomeBoardWritable);

            _trelloReadWrite.Boards.RemoveMember(_welcomeBoardWritable, member);
			var membersAfterRemoveMember = _trelloReadWrite.Members.ForBoard(_welcomeBoardWritable);

            Assert.That(membersAfterAddMember.Any(x => x.Id.Equals(Constants.MeId)));
			Assert.That(!membersAfterRemoveMember.Any(x => x.Id.Equals(Constants.MeId)));
        }

		[Test]
		public void Scenario_ChangeLabelName()
		{
			var board = _welcomeBoardWritable;
			_trelloReadWrite.Boards.ChangeLabelName(board, Color.Red, "Bug");

			var boardAfterChange = _trelloReadWrite.Boards.WithId(board.GetBoardId());
			_trelloReadWrite.Boards.ChangeLabelName(board, Color.Red, null);

			Assert.That(boardAfterChange.LabelNames[Color.Red], Is.EqualTo("Bug"));
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

		private static ExpectedObject CreateExpectedWelcomeBoard()
		{
			return new Board
			{
				Closed = false,
				Name = "Welcome Board",
				Desc = "A test description",
				IdOrganization = Constants.TestOrganizationId,
				Pinned = true,
				Url = "https://trello.com/b/J9JUdoYV/welcome-board",
				Id = Constants.WelcomeBoardId,
				Prefs = new BoardPreferences
				{
					Comments = CommentPermission.Members,
					Invitations = InvitationPermission.Members,
					PermissionLevel = PermissionLevel.Private,
					Voting = VotingPermission.Members
				},
				LabelNames = new Dictionary<Color, string>
				{
					{ Color.Yellow, "" },
					{ Color.Red, "" },
					{ Color.Purple, "" },
					{ Color.Orange, "" },
					{ Color.Green, "label name" },
					{ Color.Blue, "" },
				}
			}.ToExpectedObject();
		}
	}
}
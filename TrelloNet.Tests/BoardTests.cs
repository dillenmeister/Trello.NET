using System;
using System.Linq;
using ExpectedObjects;
using NUnit.Framework;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class BoardTests : TrelloTestBase
	{
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

		[Test]
		public void WithId_ABoardWithInvitationPermissionSetToOwner_InvitationPermissionIsOwner()
		{
			var board = _trelloReadOnly.Boards.WithId(Constants.ABoardWithInvitationPermissionSetToOwnerId);

			Assert.That(board.Prefs.Invitations, Is.EqualTo(InvitationPermission.Owners));
		}

		[Test]
		public void WithId_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Boards.WithId(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "boardId"));
		}

		[Test]
		public void ForMember_Me_ReturnsTheWelcomeBoard()
		{
			var boards = _trelloReadOnly.Boards.ForMember(new Me());

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

			Assert.That(boards, Has.Count.EqualTo(1));
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
		public void ForOrganizationn_TestOrganization_ReturnsTheWelcomeBoard()
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
			var board = _trelloReadWrite.Boards.ForMember(new Me(), BoardFilter.Open).First(b => b.Name == "Welcome Board");

			_trelloReadWrite.Boards.Close(board);

			var closedBoard = _trelloReadWrite.Boards.WithId(board.Id);
			Assert.That(closedBoard.Closed, Is.True);

			_trelloReadWrite.Boards.ReOpen(closedBoard);

			var reopenedBoard = _trelloReadWrite.Boards.WithId(board.Id);

			Assert.That(reopenedBoard.Closed, Is.False);
		}

		[Test]
		public void Scenario_ChangeName()
		{
			var board = _trelloReadWrite.Boards.ForMember(new Me(), BoardFilter.Open).First(b => b.Name == "Welcome Board");

			_trelloReadWrite.Boards.ChangeName(board, "A new name");

			var boardwithChangedName = _trelloReadWrite.Boards.WithId(board.Id);

			Assert.That(boardwithChangedName.Name, Is.EqualTo("A new name"));

			_trelloReadWrite.Boards.ChangeName(board, "Welcome Board");
		}

		[Test]
		public void Scenario_ChangeDescription()
		{
			var board = _trelloReadWrite.Boards.ForMember(new Me(), BoardFilter.Open).First(b => b.Name == "Welcome Board");

			_trelloReadWrite.Boards.ChangeDescription(board, "A new description");

			var boardwithChangedDescription = _trelloReadWrite.Boards.WithId(board.Id);

			Assert.That(boardwithChangedDescription.Desc, Is.EqualTo("A new description"));

			_trelloReadWrite.Boards.ChangeDescription(board, "");
		}

		[Test]
		public void ToString_EqualsName()
		{
			var board = new Board { Name = "a name" };

			Assert.That(board.ToString(), Is.EqualTo("a name"));			
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
				Url = "https://trello.com/board/welcome-board/" + Constants.WelcomeBoardId,
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
	}
}
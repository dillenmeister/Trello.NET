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
		public void GetById_TheWelcomeBoard_ReturnsExpectedWelcomeBoard()
		{
			var expectedBoard = CreateExpectedWelcomeBoard();

			var actualBoard = _readTrello.Boards.WithId(Constants.WelcomeBoardId);

			expectedBoard.ShouldEqual(actualBoard);
		}

		[Test]
		public void GetById_AClosedBoard_ClosedIsTrue()
		{
			var board = _readTrello.Boards.WithId(Constants.AClosedBoardId);

			Assert.That(board.Closed, Is.True);
		}


		[Test]
		public void GetById_AnUnpinnedBoard_PinnedIsFalse()
		{
			var board = _readTrello.Boards.WithId(Constants.AnUnpinnedBoard);

			Assert.That(board.Pinned, Is.False);
		}

		[Test]
		public void GetById_ABoardWithInvitationPermissionSetToOwner_InvitationPermissionIsOwner()
		{
			var board = _readTrello.Boards.WithId(Constants.ABoardWithInvitationPermissionSetToOwnerId);

			Assert.That(board.Prefs.Invitations, Is.EqualTo(InvitationPermission.Owners));
		}

		[Test]
		public void GetById_Null_Throws()
		{
			Assert.That(() => _readTrello.Boards.WithId(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "boardId"));
		}

		[Test]
		public void GetByMember_Me_ReturnsTheWelcomeBoard()
		{
			var boards = _readTrello.Boards.ForMember(new Me());

			Assert.That(boards, Has.Some.Matches<Board>(b => b.Name == "Welcome Board"));
		}

		[Test]
		public void GetByMember_Me_AllFieldsOfBoardAreMapped()
		{
			var expectedBoard = CreateExpectedWelcomeBoard();

			var actualBoard = _readTrello.Boards.ForMember(new Me()).Single(b => b.Id == Constants.WelcomeBoardId);

			expectedBoard.ShouldEqual(actualBoard);
		}

		[Test]
		public void GetByMember_MeAndClosed_ReturnsTheClosedBoard()
		{
			var boards = _readTrello.Boards.ForMember(new Me(), BoardFilter.Closed);

			Assert.That(boards, Has.Count.EqualTo(1));
			Assert.That(boards, Has.Some.Matches<Board>(b => b.Name == "A closed board"));
		}

		[Test]
		public void GetByMember_Null_Throws()
		{
			Assert.That(() => _readTrello.Boards.ForMember(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "member"));
		}

		[Test]
		public void GetByCard_TheWelcomeCard_ReturnsTheWelcomeBoard()
		{
			var expectedBoard = CreateExpectedWelcomeBoard();

			var board = _readTrello.Boards.ForCard(new CardId(Constants.WelcomeCardOfTheWelcomeBoardId));

			expectedBoard.ShouldEqual(board);
		}

		[Test]
		public void GetByCard_Null_Throws()
		{
			Assert.That(() => _readTrello.Boards.ForCard(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "card"));
		}

		[Test]
		public void GetByChecklist_TheChecklistInTheLastCardOfTheBasicsList_ReturnsTheWelcomeBoard()
		{
			var expectedBoard = CreateExpectedWelcomeBoard();

			var board = _readTrello.Boards.ForChecklist(new ChecklistId("4f2b8b4d4f2cb9d16d3684c7"));

			expectedBoard.ShouldEqual(board);
		}

		[Test]
		public void GetByChecklist_Null_Throws()
		{
			Assert.That(() => _readTrello.Boards.ForChecklist(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "checklist"));
		}

		[Test]
		public void GetByList_TheWelcomeBoardBasicsList_ReturnsTheWelcomeBoard()
		{
			var expectedBoard = CreateExpectedWelcomeBoard();

			var board = _readTrello.Boards.ForList(new ListId(Constants.WelcomeBoardBasicsListId));

			expectedBoard.ShouldEqual(board);
		}

		[Test]
		public void GetByList_Null_Throws()
		{
			Assert.That(() => _readTrello.Boards.ForList(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "list"));
		}

		[Test]
		public void GetByOrganization_TestOrganization_ReturnsTheWelcomeBoard()
		{
			var expectedBoard = CreateExpectedWelcomeBoard();

			var boards = _readTrello.Boards.ForOrganization(new OrganizationId(Constants.TestOrganizationId));

			Assert.That(boards.Count(), Is.EqualTo(1));
			expectedBoard.ShouldEqual(boards.First());
		}

		[Test]
		public void GetByOrganization_TestOrganizationAndClosed_ReturnsNoBoards()
		{
			var boards = _readTrello.Boards.ForOrganization(new OrganizationId(Constants.TestOrganizationId), BoardFilter.Closed);

			Assert.That(boards.Count(), Is.EqualTo(0));
		}

		[Test]
		public void GetByOrganization_Null_Throws()
		{
			Assert.That(() => _readTrello.Boards.ForOrganization(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "organization"));
		}

		[Test]
		public void Scenario_AddAndClose()
		{
			var newBoard = _writeTrello.Boards.Add(new NewBoard("A new board") { Desc = "the description" });

			Assert.That(newBoard, Is.Not.Null);
			Assert.That(newBoard.Name, Is.EqualTo("A new board"));
			Assert.That(newBoard.Desc, Is.EqualTo("the description"));

			_writeTrello.Boards.Close(newBoard);

			var closedBoard = _writeTrello.Boards.WithId(newBoard.Id);

			Assert.That(closedBoard.Closed, Is.True);
		}

		[Test]
		public void Scenario_CloseAndReOpen()
		{
			var board = _writeTrello.Boards.ForMember(new Me(), BoardFilter.Open).First(b => b.Name == "Welcome Board");

			_writeTrello.Boards.Close(board);

			var closedBoard = _writeTrello.Boards.WithId(board.Id);
			Assert.That(closedBoard.Closed, Is.True);

			_writeTrello.Boards.ReOpen(closedBoard);

			var reopenedBoard = _writeTrello.Boards.WithId(board.Id);

			Assert.That(reopenedBoard.Closed, Is.False);
		}

		[Test]
		public void Scenario_ChangeName()
		{
			var board = _writeTrello.Boards.ForMember(new Me(), BoardFilter.Open).First(b => b.Name == "Welcome Board");

			_writeTrello.Boards.ChangeName(board, "A new name");

			var boardwithChangedName = _writeTrello.Boards.WithId(board.Id);

			Assert.That(boardwithChangedName.Name, Is.EqualTo("A new name"));

			_writeTrello.Boards.ChangeName(board, "Welcome Board");
		}

		[Test]
		public void Scenario_ChangeDescription()
		{
			var board = _writeTrello.Boards.ForMember(new Me(), BoardFilter.Open).First(b => b.Name == "Welcome Board");

			_writeTrello.Boards.ChangeDescription(board, "A new description");

			var boardwithChangedDescription = _writeTrello.Boards.WithId(board.Id);

			Assert.That(boardwithChangedDescription.Desc, Is.EqualTo("A new description"));

			_writeTrello.Boards.ChangeDescription(board, "");
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
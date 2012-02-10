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

			var actualBoard = _trello.Boards.GetById(Constants.WelcomeBoardId);

			expectedBoard.ShouldEqual(actualBoard);
		}

		[Test]
		public void GetById_AClosedBoard_ClosedIsTrue()
		{
			var board = _trello.Boards.GetById(Constants.AClosedBoardId);

			Assert.That(board.Closed, Is.True);
		}


		[Test]
		public void GetById_AnUnpinnedBoard_PinnedIsFalse()
		{
			var board = _trello.Boards.GetById(Constants.AnUnpinnedBoard);

			Assert.That(board.Pinned, Is.False);
		}

		[Test]
		public void GetById_ABoardWithInvitationPermissionSetToOwner_InvitationPermissionIsOwner()
		{
			var board = _trello.Boards.GetById(Constants.ABoardWithInvitationPermissionSetToOwnerId);

			Assert.That(board.Prefs.Invitations, Is.EqualTo(InvitationPermission.Owners));
		}

		[Test]
		public void GetById_Null_Throws()
		{
			Assert.That(() => _trello.Boards.GetById(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "boardId"));
		}

		[Test]
		public void GetByMember_Me_ReturnsTheWelcomeBoard()
		{
			var boards = _trello.Boards.GetByMember(new Me());

			Assert.That(boards, Has.Some.Matches<Board>(b => b.Name == "Welcome Board"));
		}

		[Test]
		public void GetByMember_Me_AllFieldsOfBoardAreMapped()
		{
			var expectedBoard = CreateExpectedWelcomeBoard();

			var actualBoard = _trello.Boards.GetByMember(new Me()).Single(b => b.Id == Constants.WelcomeBoardId);

			expectedBoard.ShouldEqual(actualBoard);
		}

		[Test]
		public void GetByMember_MeAndClosed_ReturnsTheClosedBoard()
		{
			var boards = _trello.Boards.GetByMember(new Me(), BoardFilter.Closed);

			Assert.That(boards, Has.Count.EqualTo(1));
			Assert.That(boards, Has.Some.Matches<Board>(b => b.Name == "A closed board"));
		}

		[Test]
		public void GetByMember_Null_Throws()
		{
			Assert.That(() => _trello.Boards.GetByMember(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "member"));
		}

		[Test]
		public void GetByCard_TheWelcomeCard_ReturnsTheWelcomeBoard()
		{
			var expectedBoard = CreateExpectedWelcomeBoard();

			var board = _trello.Boards.GetByCard(new CardId(Constants.WelcomeCardOfTheWelcomeBoardId));

			expectedBoard.ShouldEqual(board);
		}

		[Test]
		public void GetByCard_Null_Throws()
		{
			Assert.That(() => _trello.Boards.GetByCard(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "card"));
		}

		[Test]
		public void GetByChecklist_TheChecklistInTheLastCardOfTheBasicsList_ReturnsTheWelcomeBoard()
		{
			var expectedBoard = CreateExpectedWelcomeBoard();

			var board = _trello.Boards.GetByChecklist(new ChecklistId("4f2b8b4d4f2cb9d16d3684c7"));

			expectedBoard.ShouldEqual(board);
		}

		[Test]
		public void GetByChecklist_Null_Throws()
		{
			Assert.That(() => _trello.Boards.GetByChecklist(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "checklist"));
		}

		[Test]
		public void GetByList_TheWelcomeBoardBasicsList_ReturnsTheWelcomeBoard()
		{
			var expectedBoard = CreateExpectedWelcomeBoard();

			var board = _trello.Boards.GetByList(new ListId(Constants.WelcomeBoardBasicsListId));

			expectedBoard.ShouldEqual(board);
		}

		[Test]
		public void GetByList_Null_Throws()
		{
			Assert.That(() => _trello.Boards.GetByList(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "list"));
		}

		[Test]
		public void GetByOrganization_TestOrganization_ReturnsTheWelcomeBoard()
		{
			var expectedBoard = CreateExpectedWelcomeBoard();

			var boards = _trello.Boards.GetByOrganization(new OrganizationId(Constants.TestOrganizationId));

			Assert.That(boards.Count(), Is.EqualTo(1));
			expectedBoard.ShouldEqual(boards.First());
		}

		[Test]
		public void GetByOrganization_TestOrganizationAndClosed_ReturnsNoBoards()
		{
			var boards = _trello.Boards.GetByOrganization(new OrganizationId(Constants.TestOrganizationId), BoardFilter.Closed);

			Assert.That(boards.Count(), Is.EqualTo(0));
		}

		[Test]
		public void GetByOrganization_Null_Throws()
		{
			Assert.That(() => _trello.Boards.GetByOrganization(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "organization"));
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
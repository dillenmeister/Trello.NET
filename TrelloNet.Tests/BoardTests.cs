using System.Linq;
using ExpectedObjects;
using NUnit.Framework;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class BoardTests : TrelloTestBase
	{
		[Test]
		public void Me_ReturnsCollectionThatContainsTheWelcomeBoard()
		{
			var boards = _trello.Boards(new Me());

			Assert.That(boards, Has.Some.Matches<Board>(b => b.Name == "Welcome Board"));
		}

		[Test]
		public void Me_AllFieldsOfBoardShouldBeMapped()
		{
			var expectedBoard = CreateExpectedWelcomeBoard();

			var actualBoard = _trello.Boards(new Me()).Single(b => b.Id == Constants.WelcomeBoardId);

			expectedBoard.ShouldEqual(actualBoard);
		}

		[Test]
		public void TheWelcomeBoardId_ShouldReturnTheWelcomeBoard()
		{
			var expectedBoard = CreateExpectedWelcomeBoard();

			var actualBoard = _trello.Board(Constants.WelcomeBoardId);

			expectedBoard.ShouldEqual(actualBoard);
		}

		[Test]
		public void AClosedBoardId_ClosedShouldBeTrue()
		{
			var board = _trello.Board(Constants.AClosedBoardId);

			Assert.That(board.Closed, Is.True);
		}


		[Test]
		public void AnUnpinnedBoard_PinnedShouldBeFalse()
		{
			var board = _trello.Board(Constants.AnUnpinnedBoard);

			Assert.That(board.Pinned, Is.False);
		}

		[Test]
		public void ABoardWithInvitationPermissionSetToOwnerId_InvitationPermissionShouldBeOwner()
		{
			var board = _trello.Board(Constants.ABoardWithInvitationPermissionSetToOwnerId);

			Assert.That(board.Prefs.Invitations, Is.EqualTo(InvitationPermission.Owners));
		}

		[Test]
		public void MeAndFilterClosed_ShouldReturnOnlyTheClosedBoard()
		{
			var boards = _trello.Boards(new Me(), BoardFilter.Closed);

			Assert.That(boards, Has.Count.EqualTo(1));
			Assert.That(boards, Has.Some.Matches<Board>(b => b.Name == "A closed board"));
		}

		[Test]
		public void TheWelcomeCardId_ShouldReturnTheWelcomeBoard()
		{
			var expectedBoard = CreateExpectedWelcomeBoard();

			var board = _trello.Board(new CardId(Constants.WelcomeCardOfTheWelcomeBoardId));

			expectedBoard.ShouldEqual(board);
		}

		[Test]
		public void TheChecklistIdInTheLastCardOfTheBasicsList_ShouldReturnTheWelcomeBoard()
		{
			var expectedBoard = CreateExpectedWelcomeBoard();

			var board = _trello.Board(new ChecklistId("4f2b8b4d4f2cb9d16d3684c7"));

			expectedBoard.ShouldEqual(board);
		}

		[Test]
		public void TheWelcomeBoardBasicsListId_ShouldReturnTheWelcomeBoard()
		{
			var expectedBoard = CreateExpectedWelcomeBoard();

			var board = _trello.Board(new ListId(Constants.WelcomeBoardBasicsListId));

			expectedBoard.ShouldEqual(board);
		}

		[Test]
		public void TestOrganizationId_ShouldReturnTheWelcomeBoard()
		{
			var expectedBoard = CreateExpectedWelcomeBoard();

			var boards = _trello.Boards(new OrganizationId(Constants.TestOrganizationId));

			Assert.That(boards.Count(), Is.EqualTo(1));
			expectedBoard.ShouldEqual(boards.First());
			
		}

		[Test]
		public void TestOrganizationIdAndFilterClosed_ShouldReturnNoBoards()
		{
			var boards = _trello.Boards(new OrganizationId(Constants.TestOrganizationId), BoardFilter.Closed);

			Assert.That(boards.Count(), Is.EqualTo(0));
		}

		private static ExpectedObject CreateExpectedWelcomeBoard()
		{
			var expectedBoard = new Board
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

			return expectedBoard;
		}
	}
}
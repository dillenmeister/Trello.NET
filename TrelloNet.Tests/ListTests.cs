using System;
using System.Linq;
using ExpectedObjects;
using NUnit.Framework;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class ListTests : TrelloTestBase
	{
		[Test]
		public void GetById_WelcomeBoardBasicsList_ReturnsTheBasicsList()
		{
			var expectedList = CreateExpectedBasicsList();

			var actualList = _readTrello.Lists.WithId(Constants.WelcomeBoardBasicsListId);

			expectedList.ShouldEqual(actualList);
		}

		[Test]
		public void GetById_Null_Throws()
		{
			Assert.That(() => _readTrello.Lists.WithId(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "listId"));
		}

		[Test]
		public void GetByBoard_WelcomeBoard_AllFieldsOfListAreMapped()
		{
			var expectedList = CreateExpectedBasicsList();

			var list = _readTrello.Lists.ForBoard(new BoardId(Constants.WelcomeBoardId)).Single(l => l.Id == Constants.WelcomeBoardBasicsListId);

			expectedList.ShouldEqual(list);
		}

		[Test]
		public void GetByBoard_WelcomeBoard_ReturnsThreeLists()
		{
			var lists = _readTrello.Lists.ForBoard(new BoardId(Constants.WelcomeBoardId));

			Assert.That(lists, Has.Count.EqualTo(3));
		}

		[Test]
		public void GetByBoard_WelcomeBoardAndClosed_ReturnsOneList()
		{
			var lists = _readTrello.Lists.ForBoard(new BoardId(Constants.WelcomeBoardId), ListFilter.Closed);

			Assert.That(lists, Has.Count.EqualTo(1));
		}

		[Test]
		public void GetByBoard_Null_Throws()
		{
			Assert.That(() => _readTrello.Lists.ForBoard(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "board"));
		}

		[Test]
		public void GetByCard_WelcomeCardOfTheWelcomeBoard_ReturnsWelcomeBoardBasicsList()
		{
			var expectedList = CreateExpectedBasicsList();

			var list = _readTrello.Lists.ForCard(new CardId(Constants.WelcomeCardOfTheWelcomeBoardId));

			expectedList.ShouldEqual(list);
		}

		[Test]
		public void GetByCard_Null_Throws()
		{
			Assert.That(() => _readTrello.Lists.ForCard(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "card"));
		}

		[Test]
		public void Scenario_AddAndArchive()
		{
			var board = _writeTrello.Boards.ForMember(new Me(), BoardFilter.Open).First(b => b.Name == "Welcome Board");

			var list = _writeTrello.Lists.Add(new NewList("A new list", board.Id));

			Assert.That(list.Closed, Is.False);
			Assert.That(list.IdBoard, Is.EqualTo(board.Id));
			Assert.That(list.Name, Is.EqualTo("A new list"));

			_writeTrello.Lists.Archive(list);

			var closedList = _writeTrello.Lists.WithId(list.Id);

			Assert.That(closedList.Closed, Is.True);
		}

		[Test]
		public void Scenario_ArchiveAndSendToBoard()
		{
			var board = _writeTrello.Boards.ForMember(new Me(), BoardFilter.Open).First(b => b.Name == "Welcome Board");
			var list = _writeTrello.Lists.ForBoard(board).First(l => l.Name == "Basics");

			_writeTrello.Lists.Archive(list);

			var closedList = _writeTrello.Lists.WithId(list.Id);

			Assert.That(closedList.Closed, Is.True);

			_writeTrello.Lists.SendToBoard(closedList);

			var reopenedList = _writeTrello.Lists.WithId(list.Id);

			Assert.That(reopenedList.Closed, Is.False);
		}

		[Test]
		public void Scenario_ChangeName()
		{
			var board = _writeTrello.Boards.ForMember(new Me(), BoardFilter.Open).First(b => b.Name == "Welcome Board");
			var list = _writeTrello.Lists.ForBoard(board).First(l => l.Name == "Basics");

			_writeTrello.Lists.ChangeName(list, "A new name");

			var listWithChangedName = _writeTrello.Lists.WithId(list.Id);

			Assert.That(listWithChangedName.Name, Is.EqualTo("A new name"));

			_writeTrello.Lists.ChangeName(list, "Basics");
		}

		[Test]
		public void ToString_EqualsName()
		{
			var list = new List { Name = "a name" };

			Assert.That(list.ToString(), Is.EqualTo("a name"));
		}

		private static ExpectedObject CreateExpectedBasicsList()
		{
			return new List
			{
				Closed = false,
				Id = Constants.WelcomeBoardBasicsListId,
				IdBoard = Constants.WelcomeBoardId,
				Name = "Basics"
			}.ToExpectedObject();
		}
	}
}
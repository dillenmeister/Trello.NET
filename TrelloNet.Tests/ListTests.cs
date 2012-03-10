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
		public void WithId_WelcomeBoardBasicsList_ReturnsTheBasicsList()
		{
			var expectedList = CreateExpectedBasicsList();

			var actualList = _trelloReadOnly.Lists.WithId(Constants.WelcomeBoardBasicsListId);

			expectedList.ShouldEqual(actualList);
		}

		[Test]
		public void WithId_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Lists.WithId(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "listId"));
		}

		[Test]
		public void ForBoard_WelcomeBoard_AllFieldsOfListAreMapped()
		{
			var expectedList = CreateExpectedBasicsList();

			var list = _trelloReadOnly.Lists.ForBoard(new BoardId(Constants.WelcomeBoardId)).Single(l => l.Id == Constants.WelcomeBoardBasicsListId);

			expectedList.ShouldEqual(list);
		}

		[Test]
		public void ForBoard_WelcomeBoard_ReturnsThreeLists()
		{
			var lists = _trelloReadOnly.Lists.ForBoard(new BoardId(Constants.WelcomeBoardId));

			Assert.That(lists, Has.Count.EqualTo(3));
		}

		[Test]
		public void ForBoard_WelcomeBoardAndClosed_ReturnsOneList()
		{
			var lists = _trelloReadOnly.Lists.ForBoard(new BoardId(Constants.WelcomeBoardId), ListFilter.Closed);

			Assert.That(lists, Has.Count.EqualTo(1));
		}

		[Test]
		public void ForBoard_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Lists.ForBoard(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "board"));
		}

		[Test]
		public void ForCard_WelcomeCardOfTheWelcomeBoard_ReturnsWelcomeBoardBasicsList()
		{
			var expectedList = CreateExpectedBasicsList();

			var list = _trelloReadOnly.Lists.ForCard(new CardId(Constants.WelcomeCardOfTheWelcomeBoardId));

			expectedList.ShouldEqual(list);
		}

		[Test]
		public void ForCard_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Lists.ForCard(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "card"));
		}

		[Test]
		public void Scenario_AddAndArchive()
		{
			var board = _trelloReadWrite.Boards.ForMe(BoardFilter.Open).First(b => b.Name == "Welcome Board");

			var list = _trelloReadWrite.Lists.Add(new NewList("A new list", board.Id));

			Assert.That(list.Closed, Is.False);
			Assert.That(list.IdBoard, Is.EqualTo(board.Id));
			Assert.That(list.Name, Is.EqualTo("A new list"));

			_trelloReadWrite.Lists.Archive(list);

			var closedList = _trelloReadWrite.Lists.WithId(list.Id);

			Assert.That(closedList.Closed, Is.True);
		}

		[Test]
		public void Scenario_ArchiveAndSendToBoard()
		{
			var board = _trelloReadWrite.Boards.ForMe(BoardFilter.Open).First(b => b.Name == "Welcome Board");
			var list = _trelloReadWrite.Lists.ForBoard(board).First(l => l.Name == "Basics");

			_trelloReadWrite.Lists.Archive(list);

			var closedList = _trelloReadWrite.Lists.WithId(list.Id);

			Assert.That(closedList.Closed, Is.True);

			_trelloReadWrite.Lists.SendToBoard(closedList);

			var reopenedList = _trelloReadWrite.Lists.WithId(list.Id);

			Assert.That(reopenedList.Closed, Is.False);
		}

		[Test]
		public void Scenario_ChangeName()
		{
			var board = _trelloReadWrite.Boards.ForMe(BoardFilter.Open).First(b => b.Name == "Welcome Board");
			var list = _trelloReadWrite.Lists.ForBoard(board).First(l => l.Name == "Basics");

			_trelloReadWrite.Lists.ChangeName(list, "A new name");

			var listWithChangedName = _trelloReadWrite.Lists.WithId(list.Id);

			Assert.That(listWithChangedName.Name, Is.EqualTo("A new name"));

			_trelloReadWrite.Lists.ChangeName(list, "Basics");
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
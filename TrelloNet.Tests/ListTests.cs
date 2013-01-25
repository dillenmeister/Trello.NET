using System;
using System.Linq;
using ExpectedObjects;
using NUnit.Framework;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class ListTests : TrelloTestBase
	{
		private readonly IBoardId _welcomeBoardWritable = new BoardId("4f41e4803374646b5c74bd69");
		private readonly IListId _basicsListWritable = new ListId("4f41e4803374646b5c74bd61");

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
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "id"));
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
		public void ForBoard_WelcomeBoardAndClosed_ReturnsTwoLists()
		{
			var lists = _trelloReadOnly.Lists.ForBoard(new BoardId(Constants.WelcomeBoardId), ListFilter.Closed);

			Assert.That(lists, Has.Count.EqualTo(2));
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
			var list = _trelloReadWrite.Lists.Add(new NewList("A new list", _welcomeBoardWritable));

			Assert.That(list.Closed, Is.False);
			Assert.That(list.IdBoard, Is.EqualTo(_welcomeBoardWritable.GetBoardId()));
			Assert.That(list.Name, Is.EqualTo("A new list"));

			_trelloReadWrite.Lists.Archive(list);

			var closedList = _trelloReadWrite.Lists.WithId(list.Id);

			Assert.That(closedList.Closed, Is.True);
		}

		[Test]
		public void Scenario_ArchiveAndUnarchive()
		{
			_trelloReadWrite.Lists.Archive(_basicsListWritable);

			var closedList = _trelloReadWrite.Lists.WithId(_basicsListWritable.GetListId());

			Assert.That(closedList.Closed, Is.True);

			_trelloReadWrite.Lists.Unarchive(closedList);

			var reopenedList = _trelloReadWrite.Lists.WithId(_basicsListWritable.GetListId());

			Assert.That(reopenedList.Closed, Is.False);
		}

		[Test]
		public void Scenario_ChangeName()
		{
			_trelloReadWrite.Lists.ChangeName(_basicsListWritable, "A new name");

			var listWithChangedName = _trelloReadWrite.Lists.WithId(_basicsListWritable.GetListId());

			Assert.That(listWithChangedName.Name, Is.EqualTo("A new name"));

			_trelloReadWrite.Lists.ChangeName(_basicsListWritable, "Basics");
		}

		[Test]
		public void ToString_EqualsName()
		{
			var list = new List { Name = "a name" };

			Assert.That(list.ToString(), Is.EqualTo("a name"));
		}

		[TestCase("")]
		[TestCase(null)]
		public void Add_NameIsInvalid_Throws(string name)
		{
			Assert.That(() => _trelloReadOnly.Lists.Add(new NewList(name, new BoardId("dummy"))),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "name"));
		}

		[Test]
		public void Add_NameIsTooLong_Throws()
		{
			Assert.That(() => _trelloReadOnly.Lists.Add(new NewList(new string('x', 16385), new BoardId("dummy"))),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "name"));
		}

		[TestCase("")]
		[TestCase(null)]
		public void ChangeName_NameIsInvalid_Throws(string name)
		{
			Assert.That(() => _trelloReadWrite.Lists.ChangeName(new ListId("dummy"), name),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "name"));
		}

		[Test]
		public void ChangeName_NameIsTooLong_Throws()
		{
			Assert.That(() => _trelloReadWrite.Lists.ChangeName(new ListId("dummy"), new string('x', 16385)),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "name"));
		}

		[Test]
		public void Scenario_UpdateNameAndClosed()
		{
			var list = _trelloReadWrite.Lists.WithId("4f41e4803374646b5c74bd61");

			list.Name = "Updated name";			
			list.Closed = true;

			_trelloReadWrite.Lists.Update(list);

			var listAfterUpdate = _trelloReadWrite.Lists.WithId(list.Id);

			list.Name = "Basics";
			list.Closed = false;

			_trelloReadWrite.Lists.Update(list);

			Assert.That(listAfterUpdate.Name, Is.EqualTo("Updated name"));			
			Assert.That(listAfterUpdate.Closed, Is.EqualTo(true));
		}

		[Test, Ignore("Trello does something, the position when getting the list agais is not 1234")]
		public void Scenario_ChangePosOfList()
		{
			var list = _trelloReadWrite.Lists.WithId("4f41e4803374646b5c74bd61");

			var previousPos = list.Pos;

			_trelloReadWrite.Lists.ChangePos(list, 1234);

			var listAfterPosChange = _trelloReadWrite.Lists.WithId("4f41e4803374646b5c74bd61");

			Assert.That(listAfterPosChange.Pos, Is.EqualTo(1234));
			_trelloReadWrite.Lists.ChangePos(list, previousPos);
		}

		private static ExpectedObject CreateExpectedBasicsList()
		{
			return new List
			{
				Closed = false,
				Id = Constants.WelcomeBoardBasicsListId,
				IdBoard = Constants.WelcomeBoardId,
				Name = "Basics",
				Pos = 16384
			}.ToExpectedObject();
		}
	}
}
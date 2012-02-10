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

			var actualList = _trello.Lists.GetById(Constants.WelcomeBoardBasicsListId);

			expectedList.ShouldEqual(actualList);
		}

		[Test]
		public void GetByBoard_WelcomeBoard_AllFieldsOfListAreMapped()
		{
			var expectedList = CreateExpectedBasicsList();

			var list = _trello.Lists.GetByBoard(new BoardId(Constants.WelcomeBoardId)).Single(l => l.Id == Constants.WelcomeBoardBasicsListId);

			expectedList.ShouldEqual(list);
		}

		[Test]
		public void GetByBoard_WelcomeBoard_ReturnsThreeLists()
		{
			var lists = _trello.Lists.GetByBoard(new BoardId(Constants.WelcomeBoardId));

			Assert.That(lists, Has.Count.EqualTo(3));
		}

		[Test]
		public void GetByBoard_WelcomeBoardAndClosed_ReturnsOneList()
		{
			var lists = _trello.Lists.GetByBoard(new BoardId(Constants.WelcomeBoardId), ListFilter.Closed);

			Assert.That(lists, Has.Count.EqualTo(1));
		}

		[Test]
		public void GetByCard_WelcomeCardOfTheWelcomeBoard_ReturnsWelcomeBoardBasicsList()
		{
			var expectedList = CreateExpectedBasicsList();

			var list = _trello.Lists.GetByCard(new CardId(Constants.WelcomeCardOfTheWelcomeBoardId));

			expectedList.ShouldEqual(list);
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
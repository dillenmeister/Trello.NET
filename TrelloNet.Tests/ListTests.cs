using System.Linq;
using ExpectedObjects;
using NUnit.Framework;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class ListTests : TrelloTestBase
	{
		[Test]
		public void WelcomeBoardBasicsListId_ShouldReturnTheBasicsList()
		{
			var expectedList = CreateExpectedBasicsList();

			var actualList = _trello.Lists.GetById(Constants.WelcomeBoardBasicsListId);

			expectedList.ShouldEqual(actualList);
		}

		[Test]
		public void WelcomeBoardId_AllFieldsOfListShouldBeMapped()
		{
			var expectedList = CreateExpectedBasicsList();

			var list = _trello.Lists.GetByBoard(new BoardId(Constants.WelcomeBoardId)).Single(l => l.Id == Constants.WelcomeBoardBasicsListId);

			expectedList.ShouldEqual(list);
		}

		[Test]
		public void WelcomeBoardId_ShouldReturnThreeLists()
		{
			var lists = _trello.Lists.GetByBoard(new BoardId(Constants.WelcomeBoardId));

			Assert.That(lists, Has.Count.EqualTo(3));
		}

		[Test]
		public void WelcomeBoardIdAndClosedFilter_ShouldReturnOneList()
		{
			var lists = _trello.Lists.GetByBoard(new BoardId(Constants.WelcomeBoardId), ListFilter.Closed);

			Assert.That(lists, Has.Count.EqualTo(1));
		}

		[Test]
		public void WelcomeCardOfTheWelcomeBoardId_ShouldReturnWelcomeBoardBasicsList()
		{
			var expectedList = CreateExpectedBasicsList();

			var list = _trello.Lists.GetByCard(new CardId(Constants.WelcomeCardOfTheWelcomeBoardId));

			expectedList.ShouldEqual(list);
		}

		private static ExpectedObject CreateExpectedBasicsList()
		{
			var expectedList = new List
			{
				Closed = false,
				Id = Constants.WelcomeBoardBasicsListId,
				IdBoard = Constants.WelcomeBoardId,
				Name = "Basics"
			}.ToExpectedObject();

			return expectedList;
		}
	}
}
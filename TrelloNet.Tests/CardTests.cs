using System;
using System.Collections.Generic;
using System.Linq;
using ExpectedObjects;
using NUnit.Framework;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class CardTests : TrelloTestBase
	{
		[Test]
		public void GetById_WelcomeCardOfTheWelcomeBoard_ReturnsTheWelcomeCard()
		{
			var expectedCard = CreateExpectedWelcomeCard();

			var actualCard = _readTrello.Cards.WithId(Constants.WelcomeCardOfTheWelcomeBoardId);

			expectedCard.ShouldEqual(actualCard);
		}

		[Test]
		public void GetById_ANonLabeledCard_ReturnsEmptyList()
		{
			var card = _readTrello.Cards.WithId("4f2b8b4d4f2cb9d16d3684e6");

			Assert.That(card.Labels, Is.Not.Null);
			Assert.That(card.Labels, Is.Empty);
		}

		[Test]
		public void GetById_TheOnlyLabeledCard_ContainsTwoLabels()
		{
			var expectedLabels = new List<Card.Label>
			{
			    new Card.Label { Color = "green", Name = "label name" },
			    new Card.Label { Color = "red", Name = "" }
			}.ToExpectedObject();

			var card = _readTrello.Cards.WithId("4f2b8b4d4f2cb9d16d36851b");

			expectedLabels.ShouldEqual(card.Labels);
		}

		[Test]
		public void GetById_Null_Throws()
		{
			Assert.That(() => _readTrello.Cards.WithId(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "cardId"));
		}

		[Test]
		public void GetByList_WelcomeBoardBasicsList_ReturnsSixCards()
		{
			var cards = _readTrello.Cards.ForList(new ListId(Constants.WelcomeBoardBasicsListId));

			Assert.That(cards.Count(), Is.EqualTo(6));
		}

		[Test]
		public void GetByList_WelcomeBoardBasicsList_AllFieldsOfCardAreMapped()
		{
			var expectedCard = CreateExpectedWelcomeCard();

			var card = _readTrello.Cards.ForList(new ListId(Constants.WelcomeBoardBasicsListId)).Single(c => c.Id == Constants.WelcomeCardOfTheWelcomeBoardId);

			expectedCard.ShouldEqual(card);
		}

		[Test]
		public void GetByList_WelcomeBoardBasicsListAndClosed_ReturnsOneCard()
		{
			var cards = _readTrello.Cards.ForList(new ListId(Constants.WelcomeBoardBasicsListId), CardFilter.Closed);

			Assert.That(cards.Count(), Is.EqualTo(1));
		}

		[Test]
		public void GetByList_Null_Throws()
		{
			Assert.That(() => _readTrello.Cards.ForList(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "list"));
		}

		[Test]
		public void GetByMember_Me_ReturnsTheWelcomeCardOnly()
		{
			var cards = _readTrello.Cards.ForMember(new Me());

			Assert.That(cards.Count(), Is.EqualTo(1));
			Assert.That(cards, Has.Some.Matches<Card>(c => c.Name == "Welcome to Trello!"));
		}

		[Test]
		public void GetByMember_Me_AllFieldsOfCardAreMapped()
		{
			var expectedCard = CreateExpectedWelcomeCard();

			var actualCard = _readTrello.Cards.ForMember(new Me()).Single(m => m.Id == Constants.WelcomeCardOfTheWelcomeBoardId);

			expectedCard.ShouldEqual(actualCard);
		}

		[Test]
		public void GetByMember_MeAndClosed_ReturnsTheArchivedCardOnly()
		{
			var cards = _readTrello.Cards.ForMember(new Me(), CardFilter.Closed);

			Assert.That(cards.Count(), Is.EqualTo(1));
			Assert.That(cards, Has.Some.Matches<Card>(c => c.Name == "An archived card"));
		}

		[Test]
		public void GetByMember_Null_Throws()
		{
			Assert.That(() => _readTrello.Cards.ForMember(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "member"));
		}

		[Test]
		public void GetByBoard_WelcomeBoard_Returns17Cards()
		{
			var cards = _readTrello.Cards.ForBoard(new BoardId(Constants.WelcomeBoardId));

			Assert.That(cards.Count(), Is.EqualTo(17));
		}

		[Test]
		public void GetByBoard_WelcomeBoard_AllFieldsOfCardSAreMapped()
		{
			var expectedCard = CreateExpectedWelcomeCard();

			var card = _readTrello.Cards.ForBoard(new BoardId(Constants.WelcomeBoardId)).Single(c => c.Id == Constants.WelcomeCardOfTheWelcomeBoardId);

			expectedCard.ShouldEqual(card);
		}

		[Test]
		public void GetByBoard_WelcomeBoardAndClosed_Returns1Card()
		{
			var cards = _readTrello.Cards.ForBoard(new BoardId(Constants.WelcomeBoardId), CardFilter.Closed);

			Assert.That(cards.Count(), Is.EqualTo(1));
		}

		[Test]
		public void GetByBoard_Null_Throws()
		{
			Assert.That(() => _readTrello.Cards.ForBoard(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "board"));
		}

		[Test]
		public void GetByChecklist_TheChecklistInTheLastCardOfTheBasicsList_ReturnsItsCard()
		{
			var card = _readTrello.Cards.ForChecklist(new ChecklistId("4f2b8b4d4f2cb9d16d3684c7"));

			Assert.That(card.Count(), Is.EqualTo(1));
			Assert.That(card.First().Name, Is.EqualTo("... or checklists."));
		}

		[Test]
		public void GetByChecklist_Null_Throws()
		{
			Assert.That(() => _readTrello.Cards.ForChecklist(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "checklist"));
		}

		[Test]
		public void GetByShortId_TheWelcomeCard_ReturnsTheWelcomeCard()
		{
			var expected = CreateExpectedWelcomeCard();

			var actual = _readTrello.Cards.WithShortId(1, new BoardId(Constants.WelcomeBoardId));

			expected.ShouldEqual(actual);
		}

		[Test]
		public void Scenario_AddAndDelete()
		{
			var board = _writeTrello.Boards.ForMember(new Me()).First(b => b.Name == "Welcome Board");
			var list = _writeTrello.Lists.ForBoard(board).First(l => l.Name == "Basics");

			var card = _writeTrello.Cards.Add(new NewCard("A new card", list) { Desc = "The card description" });

			Assert.That(card.Desc, Is.EqualTo("The card description"));
			Assert.That(card.Name, Is.EqualTo("A new card"));
			Assert.That(card.IdBoard, Is.EqualTo(board.Id));
			Assert.That(card.IdList, Is.EqualTo(list.Id));

			_writeTrello.Cards.Delete(card);

			var deletedCard = _writeTrello.Cards.WithId(card.Id);

			Assert.That(deletedCard, Is.Null);
		}

		[Test]
		public void Scenario_ArchiveAndSendToBoard()
		{
			var card = GetWelcomeToTrelloCard();

			_writeTrello.Cards.Archive(card);

			var archivedCard = _writeTrello.Cards.WithId(card.Id);
			Assert.That(archivedCard.Closed, Is.True);

			_writeTrello.Cards.SendToBoard(card);
			var cardSentToBoard = _writeTrello.Cards.WithId(card.Id);

			Assert.That(cardSentToBoard.Closed, Is.False);
		}

		[Test]
		public void Scenario_ChangeNameAndDescription()
		{
			var card = GetWelcomeToTrelloCard();

			_writeTrello.Cards.ChangeDescription(card, "A new description");
			_writeTrello.Cards.ChangeName(card, "A new name");

			var changedCard = _writeTrello.Cards.WithId(card.Id);

			Assert.That(changedCard.Desc, Is.EqualTo("A new description"));
			Assert.That(changedCard.Name, Is.EqualTo("A new name"));

			_writeTrello.Cards.ChangeDescription(card, "");
			_writeTrello.Cards.ChangeName(card, "Welcome to Trello!");
		}

		[Test]
		public void Scenario_MoveCard()
		{
			var welcomeBoard = _writeTrello.Boards.ForMember(new Me()).First(b => b.Name == "Welcome Board");
			var lists = _writeTrello.Lists.ForBoard(welcomeBoard).ToList();

			var from = lists.First(l => l.Name == "Basics");
			var to = lists.First(l => l.Name == "Intermediate");

			var card = _writeTrello.Cards.ForList(from).First(c => c.Name == "Welcome to Trello!");

			Assert.That(card.IdList, Is.Not.EqualTo(to.Id));

			_writeTrello.Cards.Move(card, to);

			var cardAfterMove = _writeTrello.Cards.WithId(card.Id);

			Assert.That(cardAfterMove.IdList, Is.EqualTo(to.Id));

			_writeTrello.Cards.Move(card, from);
		}

		private Card GetWelcomeToTrelloCard()
		{
			return _writeTrello.Cards.WithId("4f41e4803374646b5c74bdb0");
		}

		private static ExpectedObject CreateExpectedWelcomeCard()
		{
			return new Card
			{
				Id = Constants.WelcomeCardOfTheWelcomeBoardId,
				Name = "Welcome to Trello!",
				Desc = "",
				Closed = false,
				IdList = Constants.WelcomeBoardBasicsListId,
				IdBoard = Constants.WelcomeBoardId,
				Due = new DateTime(2015, 01, 01, 10, 00, 00),
				Labels = new List<Card.Label>(),
				IdShort = 1,
				Badges = new Card.CardBadges
				{
					Votes = 1,
					Attachments = 0,
					Comments = 2,
					CheckItems = 0,
					CheckItemsChecked = 0,
					Description = false,
					Due = new DateTime(2015, 01, 01, 10, 00, 00),
					FogBugz = ""
				}
			}.ToExpectedObject();
		}
	}
}
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

			var actualCard = _trello.Cards.GetById(Constants.WelcomeCardOfTheWelcomeBoardId);

			expectedCard.ShouldEqual(actualCard);
		}

		[Test]
		public void GetById_ANonLabeledCard_ReturnsEmptyList()
		{
			var card = _trello.Cards.GetById("4f2b8b4d4f2cb9d16d3684e6");

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

			var card = _trello.Cards.GetById("4f2b8b4d4f2cb9d16d36851b");

			expectedLabels.ShouldEqual(card.Labels);
		}

		[Test]
		public void GetByList_WelcomeBoardBasicsList_ReturnsSixCards()
		{
			var cards = _trello.Cards.GetByList(new ListId(Constants.WelcomeBoardBasicsListId));

			Assert.That(cards.Count(), Is.EqualTo(6));
		}

		[Test]
		public void GetByList_WelcomeBoardBasicsList_AllFieldsOfCardAreMapped()
		{
			var expectedCard = CreateExpectedWelcomeCard();

			var card = _trello.Cards.GetByList(new ListId(Constants.WelcomeBoardBasicsListId)).Single(c => c.Id == Constants.WelcomeCardOfTheWelcomeBoardId);

			expectedCard.ShouldEqual(card);
		}

		[Test]
		public void GetByList_WelcomeBoardBasicsListAndClosed_ReturnsOneCard()
		{
			var cards = _trello.Cards.GetByList(new ListId(Constants.WelcomeBoardBasicsListId), CardFilter.Closed);

			Assert.That(cards.Count(), Is.EqualTo(1));
		}

		[Test]
		public void GetByMember_Me_ReturnsTheWelcomeCardOnly()
		{
			var cards = _trello.Cards.GetByMember(new Me());

			Assert.That(cards.Count(), Is.EqualTo(1));
			Assert.That(cards, Has.Some.Matches<Card>(c => c.Name == "Welcome to Trello!"));
		}

		[Test]
		public void GetByMember_Me_AllFieldsOfCardAreMapped()
		{
			var expectedCard = CreateExpectedWelcomeCard();

			var actualCard = _trello.Cards.GetByMember(new Me()).Single(m => m.Id == Constants.WelcomeCardOfTheWelcomeBoardId);

			expectedCard.ShouldEqual(actualCard);
		}

		[Test]
		public void GetByMember_MeAndClosed_ReturnsTheArchivedCardOnly()
		{
			var cards = _trello.Cards.GetByMember(new Me(), CardFilter.Closed);

			Assert.That(cards.Count(), Is.EqualTo(1));
			Assert.That(cards, Has.Some.Matches<Card>(c => c.Name == "An archived card"));
		}

		[Test]
		public void GetByBoard_WelcomeBoard_Returns17Cards()
		{
			var cards = _trello.Cards.GetByBoard(new BoardId(Constants.WelcomeBoardId));

			Assert.That(cards.Count(), Is.EqualTo(17));
		}

		[Test]
		public void GetByBoard_WelcomeBoard_AllFieldsOfCardSAreMapped()
		{
			var expectedCard = CreateExpectedWelcomeCard();

			var card = _trello.Cards.GetByBoard(new BoardId(Constants.WelcomeBoardId)).Single(c => c.Id == Constants.WelcomeCardOfTheWelcomeBoardId);

			expectedCard.ShouldEqual(card);
		}

		[Test]
		public void GetByBoard_WelcomeBoardAndClosed_Returns1Card()
		{
			var cards = _trello.Cards.GetByBoard(new BoardId(Constants.WelcomeBoardId), CardFilter.Closed);

			Assert.That(cards.Count(), Is.EqualTo(1));
		}

		[Test]
		public void GetByChecklist_TheChecklistInTheLastCardOfTheBasicsList_ReturnsItsCard()
		{
			var card = _trello.Cards.GetByChecklist(new ChecklistId("4f2b8b4d4f2cb9d16d3684c7"));

			Assert.That(card.Count(), Is.EqualTo(1));
			Assert.That(card.First().Name, Is.EqualTo("... or checklists."));
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
				IdShort = 1
			}.ToExpectedObject();
		}
	}
}
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
		public void WelcomeBoardBasicsListId_ShouldReturnSixCards()
		{
			var cards = _trello.Cards.GetByList(new ListId(Constants.WelcomeBoardBasicsListId));

			Assert.That(cards.Count(), Is.EqualTo(6));
		}

		[Test]
		public void WelcomeBoardBasicsListId_AllFieldsOfCardShouldBeMapped()
		{
			var expectedCard = CreateExpectedWelcomeCard();

			var card = _trello.Cards.GetByList(new ListId(Constants.WelcomeBoardBasicsListId)).Single(c => c.Id == Constants.WelcomeCardOfTheWelcomeBoardId);

			expectedCard.ShouldEqual(card);
		}

		[Test]
		public void WelcomeBoardBasicsListIdAndClosedFilter_ShouldReturnOneCard()
		{
			var cards = _trello.Cards.GetByList(new ListId(Constants.WelcomeBoardBasicsListId), CardFilter.Closed);

			Assert.That(cards.Count(), Is.EqualTo(1));
		}

		[Test]
		public void WelcomeCardOfTheWelcomeBoardId_ShouldReturnTheWelcomeToTrelloCard()
		{
			var expectedCard = CreateExpectedWelcomeCard();

			var actualCard = _trello.Cards.GetById(Constants.WelcomeCardOfTheWelcomeBoardId);

			expectedCard.ShouldEqual(actualCard);
		}

		[Test]
		public void Me_ShouldReturnTheWelcomeToTrelloCardOnly()
		{
			var cards = _trello.Cards.GetByMember(new Me());

			Assert.That(cards.Count(), Is.EqualTo(1));
			Assert.That(cards, Has.Some.Matches<Card>(c => c.Name == "Welcome to Trello!"));
		}

		[Test]
		public void Me_AllFieldsOfCardShouldBeMapped()
		{
			var expectedCard = CreateExpectedWelcomeCard();

			var actualCard = _trello.Cards.GetByMember(new Me()).Single(m => m.Id == Constants.WelcomeCardOfTheWelcomeBoardId);

			expectedCard.ShouldEqual(actualCard);
		}

		[Test]
		public void MeAndClosedFilter_ShouldReturnTheArchiveCardOnly()
		{
			var cards = _trello.Cards.GetByMember(new Me(), CardFilter.Closed);

			Assert.That(cards.Count(), Is.EqualTo(1));
			Assert.That(cards, Has.Some.Matches<Card>(c => c.Name == "An archived card"));
		}

		[Test]
		public void WelcomeBoardId_ShouldReturn17Cards()
		{
			var cards = _trello.Cards.GetByBoard(new BoardId(Constants.WelcomeBoardId));

			Assert.That(cards.Count(), Is.EqualTo(17));
		}

		[Test]
		public void WelcomeBoardId_AllFieldsOfCardShouldBeMapped()
		{
			var expectedCard = CreateExpectedWelcomeCard();

			var card = _trello.Cards.GetByBoard(new BoardId(Constants.WelcomeBoardId)).Single(c => c.Id == Constants.WelcomeCardOfTheWelcomeBoardId);

			expectedCard.ShouldEqual(card);
		}

		[Test]
		public void WelcomeBoardIdAndClosedFilter_ShouldReturn1Card()
		{
			var cards = _trello.Cards.GetByBoard(new BoardId(Constants.WelcomeBoardId), CardFilter.Closed);

			Assert.That(cards.Count(), Is.EqualTo(1));
		}

		[Test]
		public void TheChecklistIdInTheLastCardOfTheBasicsList_ShouldReturnItsCard()
		{
			var card = _trello.Cards.GetByChecklist(new ChecklistId("4f2b8b4d4f2cb9d16d3684c7"));

			Assert.That(card.Count(), Is.EqualTo(1));
			Assert.That(card.First().Name, Is.EqualTo("... or checklists."));
		}

		[Test]
		public void TheIdOfTheOnlyLabeledCard_ShouldContainTwoLabels()
		{
			var card = _trello.Cards.GetById("4f2b8b4d4f2cb9d16d36851b");
			var expectedLabels = new List<Card.Label>
			{
			    new Card.Label { Color = "green", Name = "label name" },
			    new Card.Label { Color = "red", Name = "" }
			}.ToExpectedObject();

			expectedLabels.ShouldEqual(card.Labels);
		}

		[Test]
		public void IdOfANonLabeledCard_ShouldReturnEmptyList()
		{
			var card = _trello.Cards.GetById("4f2b8b4d4f2cb9d16d3684e6");

			Assert.That(card.Labels, Is.Not.Null);
			Assert.That(card.Labels, Is.Empty);
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
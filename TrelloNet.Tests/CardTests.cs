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
		public void WithId_WelcomeCardOfTheWelcomeBoard_ReturnsTheWelcomeCard()
		{
			var expectedCard = CreateExpectedWelcomeCard();

			var actualCard = _readTrello.Cards.WithId(Constants.WelcomeCardOfTheWelcomeBoardId);

			expectedCard.ShouldEqual(actualCard);
		}

		[Test]
		public void WithId_ANonLabeledCard_ReturnsEmptyList()
		{
			var card = _readTrello.Cards.WithId("4f2b8b4d4f2cb9d16d3684e6");

			Assert.That(card.Labels, Is.Not.Null);
			Assert.That(card.Labels, Is.Empty);
		}

		[Test]
		public void WithId_TheOnlyLabeledCard_ContainsTwoLabels()
		{
			var expectedLabels = new List<Card.Label>
			{
			    new Card.Label { Color = Color.Green, Name = "label name" },
			    new Card.Label { Color = Color.Red, Name = "" }
			}.ToExpectedObject();

			var card = _readTrello.Cards.WithId("4f2b8b4d4f2cb9d16d36851b");

			expectedLabels.ShouldEqual(card.Labels);
		}

		[Test]
		public void WithId_Null_Throws()
		{
			Assert.That(() => _readTrello.Cards.WithId(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "cardId"));
		}

		[Test]
		public void ForList_WelcomeBoardBasicsList_ReturnsSixCards()
		{
			var cards = _readTrello.Cards.ForList(new ListId(Constants.WelcomeBoardBasicsListId));

			Assert.That(cards.Count(), Is.EqualTo(6));
		}

		[Test]
		public void ForList_WelcomeBoardBasicsList_AllFieldsOfCardAreMapped()
		{
			var expectedCard = CreateExpectedWelcomeCard();

			var card = _readTrello.Cards.ForList(new ListId(Constants.WelcomeBoardBasicsListId)).Single(c => c.Id == Constants.WelcomeCardOfTheWelcomeBoardId);

			expectedCard.ShouldEqual(card);
		}

		[Test]
		public void ForList_WelcomeBoardBasicsListAndClosed_ReturnsOneCard()
		{
			var cards = _readTrello.Cards.ForList(new ListId(Constants.WelcomeBoardBasicsListId), CardFilter.Closed);

			Assert.That(cards.Count(), Is.EqualTo(1));
		}

		[Test]
		public void ForList_Null_Throws()
		{
			Assert.That(() => _readTrello.Cards.ForList(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "list"));
		}

		[Test]
		public void ForMember_Me_ReturnsTheWelcomeCardOnly()
		{
			var cards = _readTrello.Cards.ForMember(new Me());

			Assert.That(cards.Count(), Is.EqualTo(1));
			Assert.That(cards, Has.Some.Matches<Card>(c => c.Name == "Welcome to Trello!"));
		}

		[Test]
		public void ForMember_Me_AllFieldsOfCardAreMapped()
		{
			var expectedCard = CreateExpectedWelcomeCard();

			var actualCard = _readTrello.Cards.ForMember(new Me()).Single(m => m.Id == Constants.WelcomeCardOfTheWelcomeBoardId);

			expectedCard.ShouldEqual(actualCard);
		}

		[Test]
		public void ForMember_MeAndClosed_ReturnsTheArchivedCardOnly()
		{
			var cards = _readTrello.Cards.ForMember(new Me(), CardFilter.Closed);

			Assert.That(cards.Count(), Is.EqualTo(1));
			Assert.That(cards, Has.Some.Matches<Card>(c => c.Name == "An archived card"));
		}

		[Test]
		public void ForMember_Null_Throws()
		{
			Assert.That(() => _readTrello.Cards.ForMember(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "member"));
		}

		[Test]
		public void ForBoard_WelcomeBoard_Returns17Cards()
		{
			var cards = _readTrello.Cards.ForBoard(new BoardId(Constants.WelcomeBoardId));

			Assert.That(cards.Count(), Is.EqualTo(17));
		}

		[Test]
		public void ForBoard_WelcomeBoard_AllFieldsOfCardSAreMapped()
		{
			var expectedCard = CreateExpectedWelcomeCard();

			var card = _readTrello.Cards.ForBoard(new BoardId(Constants.WelcomeBoardId)).Single(c => c.Id == Constants.WelcomeCardOfTheWelcomeBoardId);

			expectedCard.ShouldEqual(card);
		}

		[Test]
		public void ForBoard_WelcomeBoardAndClosed_Returns1Card()
		{
			var cards = _readTrello.Cards.ForBoard(new BoardId(Constants.WelcomeBoardId), CardFilter.Closed);

			Assert.That(cards.Count(), Is.EqualTo(1));
		}

		[Test]
		public void ForBoard_Null_Throws()
		{
			Assert.That(() => _readTrello.Cards.ForBoard(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "board"));
		}

		[Test]
		public void ForChecklist_TheChecklistInTheLastCardOfTheBasicsList_ReturnsItsCard()
		{
			var card = _readTrello.Cards.ForChecklist(new ChecklistId("4f2b8b4d4f2cb9d16d3684c7"));

			Assert.That(card.Count(), Is.EqualTo(1));
			Assert.That(card.First().Name, Is.EqualTo("... or checklists."));
		}

		[Test]
		public void ForChecklist_Null_Throws()
		{
			Assert.That(() => _readTrello.Cards.ForChecklist(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "checklist"));
		}

		[Test]
		public void WithShortId_TheWelcomeCard_ReturnsTheWelcomeCard()
		{
			var expected = CreateExpectedWelcomeCard();

			var actual = _readTrello.Cards.WithShortId(1, new BoardId(Constants.WelcomeBoardId));

			expected.ShouldEqual(actual);
		}

		[Test]
		public void GetByCard_TheChecklistCard_HasCheckitemStates()
		{
			var checkListCard = _readTrello.Cards.WithId("4f2b8b4d4f2cb9d16d3684fc");

			var first = checkListCard.CheckItemStates.First();

			Assert.That(checkListCard.CheckItemStates.Count, Is.EqualTo(1));
			Assert.That(first.State, Is.EqualTo("complete"));
			Assert.That(first.IdCheckItem, Is.EqualTo("4f2b8b4d4f2cb9d16d3684c4"));

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

		[Test]
		public void Scenario_AddAndRemoveLabel()
		{
			var card = GetWelcomeToTrelloCard();

			Assert.That(card.Labels.All(l => l.Color != Color.Purple));

			_writeTrello.Cards.AddLabel(card, Color.Purple);

			var cardAfterLabelAdded = _writeTrello.Cards.WithId(card.Id);

			Assert.That(cardAfterLabelAdded.Labels.Any(l => l.Color == Color.Purple));

			_writeTrello.Cards.RemoveLabel(card, Color.Purple);

			var cardAfterLabelRemoved = _writeTrello.Cards.WithId(card.Id);

			Assert.That(cardAfterLabelRemoved.Labels.All(l => l.Color != Color.Purple));
		}

		[Test]
		public void Scenario_AddAndRemoveMember()
		{
			var card = GetWelcomeToTrelloCard();
			var member = _writeTrello.Members.WithId("trello");
			var membersForCard = _writeTrello.Members.ForCard(card);

			Assert.That(membersForCard.All(m => m.Username != "trello"));

			_writeTrello.Cards.AddMember(card, member);

			var membersForCardAfterAdd = _writeTrello.Members.ForCard(card);

			Assert.That(membersForCardAfterAdd.Any(m => m.Username == "trello"));

			_writeTrello.Cards.RemoveMember(card, member);

			var membersForCardAfterRemove = _writeTrello.Members.ForCard(card);

			Assert.That(membersForCardAfterRemove.All(m => m.Username != "trello"));
		}

		[Test]
		public void Scenario_AddComment()
		{
			var card = GetWelcomeToTrelloCard();
			var expectedComments = card.Badges.Comments + 1;

			_writeTrello.Cards.AddComment(card, "a test comment");

			var cardAfterComment = GetWelcomeToTrelloCard();
			var actualComments = cardAfterComment.Badges.Comments;

			Assert.That(actualComments, Is.EqualTo(expectedComments));
		}

		[Test]
		public void Scenario_AddAndRemoveChecklist()
		{
			var card = GetWelcomeToTrelloCard();			
			var checklist = _writeTrello.Checklists.Add("a test checklist", new BoardId(card.IdBoard));

			_writeTrello.Cards.AddChecklist(card, checklist);
			var checklistsAfterAdd = _writeTrello.Checklists.ForCard(card);
			Assert.That(checklistsAfterAdd.Any(c => c.Id == checklist.Id));

			_writeTrello.Cards.RemoveChecklist(card, checklist);
			var checklistsAfterRemove = _writeTrello.Checklists.ForCard(card);
			Assert.That(checklistsAfterRemove.All(c => c.Id != checklist.Id));
		}

		[Test]
		public void ToString_EqualsName()
		{
			var card = new Card { Name = "a name" };

			Assert.That(card.ToString(), Is.EqualTo("a name"));
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
				CheckItemStates = new List<Card.CheckItemState>(),
				Badges = new Card.CardBadges
				{
					Votes = 1,
					Attachments = 1,
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
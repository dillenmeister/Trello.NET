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

			var actualCard = _trelloReadOnly.Cards.WithId(Constants.WelcomeCardOfTheWelcomeBoardId);

			expectedCard.ShouldEqual(actualCard);
		}

		[Test]
		public void WithId_ANonLabeledCard_ReturnsEmptyList()
		{
			var card = _trelloReadOnly.Cards.WithId("4f2b8b4d4f2cb9d16d3684e6");

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

			var card = _trelloReadOnly.Cards.WithId("4f2b8b4d4f2cb9d16d36851b");

			expectedLabels.ShouldEqual(card.Labels);
		}

		[Test]
		public void WithId_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Cards.WithId(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "cardId"));
		}

		[Test]
		public void ForList_WelcomeBoardBasicsList_ReturnsSixCards()
		{
			var cards = _trelloReadOnly.Cards.ForList(new ListId(Constants.WelcomeBoardBasicsListId));

			Assert.That(cards.Count(), Is.EqualTo(6));
		}

		[Test]
		public void ForList_WelcomeBoardBasicsList_AllFieldsOfCardAreMapped()
		{
			var expectedCard = CreateExpectedWelcomeCard();

			var card = _trelloReadOnly.Cards.ForList(new ListId(Constants.WelcomeBoardBasicsListId)).Single(c => c.Id == Constants.WelcomeCardOfTheWelcomeBoardId);

			expectedCard.ShouldEqual(card);
		}

		[Test]
		public void ForList_WelcomeBoardBasicsListAndClosed_ReturnsOneCard()
		{
			var cards = _trelloReadOnly.Cards.ForList(new ListId(Constants.WelcomeBoardBasicsListId), CardFilter.Closed);

			Assert.That(cards.Count(), Is.EqualTo(1));
		}

		[Test]
		public void ForList_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Cards.ForList(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "list"));
		}

		[Test]
		public void ForMember_Me_ReturnsTheWelcomeCardOnly()
		{
			var cards = _trelloReadOnly.Cards.ForMember(new Me());

			Assert.That(cards.Count(), Is.EqualTo(1));
			Assert.That(cards, Has.Some.Matches<Card>(c => c.Name == "Welcome to Trello!"));
		}

		[Test]
		public void ForMe_Always_ReturnsTheWelcomeCardOnly()
		{
			var cards = _trelloReadOnly.Cards.ForMe();

			Assert.That(cards.Count(), Is.EqualTo(1));
			Assert.That(cards, Has.Some.Matches<Card>(c => c.Name == "Welcome to Trello!"));
		}

		[Test]
		public void ForMember_Me_AllFieldsOfCardAreMapped()
		{
			var expectedCard = CreateExpectedWelcomeCard();

			var actualCard = _trelloReadOnly.Cards.ForMember(new Me()).Single(m => m.Id == Constants.WelcomeCardOfTheWelcomeBoardId);

			expectedCard.ShouldEqual(actualCard);
		}

		[Test]
		public void ForMember_MeAndClosed_ReturnsTheArchivedCardOnly()
		{
			var cards = _trelloReadOnly.Cards.ForMember(new Me(), CardFilter.Closed);

			Assert.That(cards.Count(), Is.EqualTo(1));
			Assert.That(cards, Has.Some.Matches<Card>(c => c.Name == "An archived card"));
		}

		[Test]
		public void ForMember_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Cards.ForMember(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "member"));
		}

		[Test]
		public void ForBoard_WelcomeBoard_Returns17Cards()
		{
			var cards = _trelloReadOnly.Cards.ForBoard(new BoardId(Constants.WelcomeBoardId));

			Assert.That(cards.Count(), Is.EqualTo(17));
		}

		[Test]
		public void ForBoard_WelcomeBoard_AllFieldsOfCardSAreMapped()
		{
			var expectedCard = CreateExpectedWelcomeCard();

			var card = _trelloReadOnly.Cards.ForBoard(new BoardId(Constants.WelcomeBoardId)).Single(c => c.Id == Constants.WelcomeCardOfTheWelcomeBoardId);

			expectedCard.ShouldEqual(card);
		}

		[Test]
		public void ForBoard_WelcomeBoardAndClosed_Returns1Card()
		{
			var cards = _trelloReadOnly.Cards.ForBoard(new BoardId(Constants.WelcomeBoardId), BoardCardFilter.Closed);

			Assert.That(cards.Count(), Is.EqualTo(1));
		}

		[Test]
		public void ForBoard_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Cards.ForBoard(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "board"));
		}

		[Test]
		public void ForChecklist_TheChecklistInTheLastCardOfTheBasicsList_ReturnsItsCard()
		{
			var card = _trelloReadOnly.Cards.ForChecklist(new ChecklistId("4f2b8b4d4f2cb9d16d3684c7"));

			Assert.That(card.Count(), Is.EqualTo(1));
			Assert.That(card.First().Name, Is.EqualTo("... or checklists."));
		}

		[Test]
		public void ForChecklist_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Cards.ForChecklist(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "checklist"));
		}

		[Test]
		public void WithShortId_TheWelcomeCard_ReturnsTheWelcomeCard()
		{
			var expected = CreateExpectedWelcomeCard();

			var actual = _trelloReadOnly.Cards.WithShortId(1, new BoardId(Constants.WelcomeBoardId));

			expected.ShouldEqual(actual);
		}

		[Test]
		public void GetByCard_TheChecklistCard_HasCheckitemStates()
		{
			var checkListCard = _trelloReadOnly.Cards.WithId("4f2b8b4d4f2cb9d16d3684fc");

			var first = checkListCard.CheckItemStates.First();

			Assert.That(checkListCard.CheckItemStates.Count, Is.EqualTo(1));
			Assert.That(first.State, Is.EqualTo("complete"));
			Assert.That(first.IdCheckItem, Is.EqualTo("4f2b8b4d4f2cb9d16d3684c4"));

		}

		[Test]
		public void Scenario_ChangeDueDate()
		{
			var card = GetWelcomeToTrelloCard();

			_trelloReadWrite.Cards.ChangeDueDate(card, new DateTime(2015, 01, 01));

			var cardAfterChange = GetWelcomeToTrelloCard();

			Assert.That(cardAfterChange.Due, Is.EqualTo(new DateTime(2015, 01, 01)));

			_trelloReadWrite.Cards.ChangeDueDate(card, null);
		}

		[Test]
		public void Scenario_AddAndDelete()
		{
			var board = _trelloReadWrite.Boards.ForMe().First(b => b.Name == "Welcome Board");
			var list = _trelloReadWrite.Lists.ForBoard(board).First(l => l.Name == "Basics");

			var card = _trelloReadWrite.Cards.Add(new NewCard("A new card", list) { Desc = "The card description" });

			Assert.That(card.Desc, Is.EqualTo("The card description"));
			Assert.That(card.Name, Is.EqualTo("A new card"));
			Assert.That(card.IdBoard, Is.EqualTo(board.Id));
			Assert.That(card.IdList, Is.EqualTo(list.Id));

			_trelloReadWrite.Cards.Delete(card);

			var deletedCard = _trelloReadWrite.Cards.WithId(card.Id);

			Assert.That(deletedCard, Is.Null);
		}

		[Test]
		public void Scenario_ArchiveAndSendToBoard()
		{
			var card = GetWelcomeToTrelloCard();

			_trelloReadWrite.Cards.Archive(card);

			var archivedCard = _trelloReadWrite.Cards.WithId(card.Id);
			Assert.That(archivedCard.Closed, Is.True);

			_trelloReadWrite.Cards.SendToBoard(card);
			var cardSentToBoard = _trelloReadWrite.Cards.WithId(card.Id);

			Assert.That(cardSentToBoard.Closed, Is.False);
		}

		[Test]
		public void Scenario_ChangeNameAndDescription()
		{
			var card = GetWelcomeToTrelloCard();

			_trelloReadWrite.Cards.ChangeDescription(card, "A new description");
			_trelloReadWrite.Cards.ChangeName(card, "A new name");

			var changedCard = _trelloReadWrite.Cards.WithId(card.Id);

			Assert.That(changedCard.Desc, Is.EqualTo("A new description"));
			Assert.That(changedCard.Name, Is.EqualTo("A new name"));

			_trelloReadWrite.Cards.ChangeDescription(card, "");
			_trelloReadWrite.Cards.ChangeName(card, "Welcome to Trello!");
		}

		[Test]
		public void Scenario_MoveCard()
		{
			var welcomeBoard = _trelloReadWrite.Boards.ForMe().First(b => b.Name == "Welcome Board");
			var lists = _trelloReadWrite.Lists.ForBoard(welcomeBoard).ToList();

			var from = lists.First(l => l.Name == "Basics");
			var to = lists.First(l => l.Name == "Intermediate");

			var card = _trelloReadWrite.Cards.ForList(from).First(c => c.Name == "Welcome to Trello!");

			Assert.That(card.IdList, Is.Not.EqualTo(to.Id));

			_trelloReadWrite.Cards.Move(card, to);

			var cardAfterMove = _trelloReadWrite.Cards.WithId(card.Id);

			Assert.That(cardAfterMove.IdList, Is.EqualTo(to.Id));

			_trelloReadWrite.Cards.Move(card, from);
		}

		[Test]
		public void Scenario_AddAndRemoveLabel()
		{
			var card = GetWelcomeToTrelloCard();

			Assert.That(card.Labels.All(l => l.Color != Color.Purple));

			_trelloReadWrite.Cards.AddLabel(card, Color.Purple);

			var cardAfterLabelAdded = _trelloReadWrite.Cards.WithId(card.Id);

			Assert.That(cardAfterLabelAdded.Labels.Any(l => l.Color == Color.Purple));

			_trelloReadWrite.Cards.RemoveLabel(card, Color.Purple);

			var cardAfterLabelRemoved = _trelloReadWrite.Cards.WithId(card.Id);

			Assert.That(cardAfterLabelRemoved.Labels.All(l => l.Color != Color.Purple));
		}

		[Test]
		public void Scenario_AddAndRemoveMember()
		{
			var card = GetWelcomeToTrelloCard();
			var member = _trelloReadWrite.Members.WithId("trello");
			var membersForCard = _trelloReadWrite.Members.ForCard(card);

			Assert.That(membersForCard.All(m => m.Username != "trello"));

			_trelloReadWrite.Cards.AddMember(card, member);

			var membersForCardAfterAdd = _trelloReadWrite.Members.ForCard(card);

			Assert.That(membersForCardAfterAdd.Any(m => m.Username == "trello"));

			_trelloReadWrite.Cards.RemoveMember(card, member);

			var membersForCardAfterRemove = _trelloReadWrite.Members.ForCard(card);

			Assert.That(membersForCardAfterRemove.All(m => m.Username != "trello"));
		}

		[Test]
		public void Scenario_AddComment()
		{
			var card = GetWelcomeToTrelloCard();
			var expectedComments = card.Badges.Comments + 1;

			_trelloReadWrite.Cards.AddComment(card, "a test comment");

			var cardAfterComment = GetWelcomeToTrelloCard();
			var actualComments = cardAfterComment.Badges.Comments;

			Assert.That(actualComments, Is.EqualTo(expectedComments));
		}

		[Test]
		public void Scenario_AddAndRemoveChecklist()
		{
			var card = GetWelcomeToTrelloCard();
			var checklist = _trelloReadWrite.Checklists.Add("a test checklist", new BoardId(card.IdBoard));

			_trelloReadWrite.Cards.AddChecklist(card, checklist);
			var checklistsAfterAdd = _trelloReadWrite.Checklists.ForCard(card);
			Assert.That(checklistsAfterAdd.Any(c => c.Id == checklist.Id));

			_trelloReadWrite.Cards.RemoveChecklist(card, checklist);
			var checklistsAfterRemove = _trelloReadWrite.Checklists.ForCard(card);
			Assert.That(checklistsAfterRemove.All(c => c.Id != checklist.Id));
		}

		[Test]
		public void Scenario_UpdateNameDescriptionClosedIdListAndDue()
		{
			var card = GetWelcomeToTrelloCard();			

			card.Name = "Updated name";
			card.Desc = "Updated description";
			card.Closed = true;
			card.IdList = "4f41e4803374646b5c74bd62";
			card.Due = new DateTime(2015, 02, 03);

			_trelloReadWrite.Cards.Update(card);

			var cardAfterUpdate = _trelloReadWrite.Cards.WithId(card.Id);
			
			card.Name = "Welcome to Trello!";
			card.Desc = "";
			card.Closed = false;
			card.IdList = "4f41e4803374646b5c74bd61";
			card.Due = null;

			_trelloReadWrite.Cards.Update(card);

			Assert.That(cardAfterUpdate.Name, Is.EqualTo("Updated name"));
			Assert.That(cardAfterUpdate.Desc, Is.EqualTo("Updated description"));
			Assert.That(cardAfterUpdate.Closed, Is.EqualTo(true));
			Assert.That(cardAfterUpdate.IdList, Is.EqualTo("4f41e4803374646b5c74bd62"));
			Assert.That(cardAfterUpdate.Due, Is.EqualTo(new DateTime(2015, 02, 03)));
		}

		[Test]
		public void ToString_EqualsName()
		{
			var card = new Card { Name = "a name" };

			Assert.That(card.ToString(), Is.EqualTo("a name"));
		}

		[TestCase("")]
		[TestCase(null)]
		public void Add_NameIsInvalid_Throws(string name)
		{
			Assert.That(() => _trelloReadOnly.Cards.Add(new NewCard(name, new ListId("dummy"))),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "name"));
		}

		[TestCase("")]
		[TestCase(null)]
		public void AddOverload_NameIsInvalid_Throws(string name)
		{
			Assert.That(() => _trelloReadOnly.Cards.Add(name, new ListId("dummy")),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "name"));
		}

		[Test]
		public void Add_DescriptionIsTooLong_Throws()
		{
			Assert.That(() => 
				_trelloReadOnly.Cards.Add(new NewCard("dummy", new ListId("dummy")) { Desc = new string('x', 16385) }),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "desc"));
		}

		[Test]
		public void Add_NameIsTooLong_Throws()
		{
			Assert.That(() => _trelloReadOnly.Cards.Add(new NewCard(new string('x', 16385), new ListId("dummy"))),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "name"));
		}

		[TestCase("")]
		[TestCase(null)]
		public void Add_ListIdIsInvalid_Throws(string listId)
		{
			Assert.That(() => _trelloReadOnly.Cards.Add(new NewCard("dummy", new ListId(listId))),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "listId"));
		}

		[Test]
		public void ChangeDescription_DescriptionIsTooLong_Throws()
		{
			Assert.That(() => _trelloReadWrite.Cards.ChangeDescription(new CardId("dummy"), new string('x', 16385)),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "desc"));
		}

		[TestCase("")]
		[TestCase(null)]
		public void ChangeName_NameIsInvalid_Throws(string name)
		{
			Assert.That(() => _trelloReadWrite.Cards.ChangeName(new CardId("dummy"), name),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "name"));
		}

		[Test]
		public void ChangeName_NameIsTooLong_Throws()
		{
			Assert.That(() => _trelloReadWrite.Cards.ChangeName(new CardId("dummy"), new string('x', 16385)),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "name"));
		}

		[TestCase("")]
		[TestCase(null)]
		public void AddComment_CommentIsInvalid_Throws(string comment)
		{
			Assert.That(() => _trelloReadWrite.Cards.AddComment(new CardId("dummy"), comment),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "comment"));
		}

		[Test]
		public void AddComment_CommentIsTooLong_Throws()
		{
			Assert.That(() => _trelloReadWrite.Cards.AddComment(new CardId("dummy"), new string('x', 16385)),
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "comment"));
		}

		private Card GetWelcomeToTrelloCard()
		{
			return _trelloReadWrite.Cards.WithId("4f41e4803374646b5c74bdb0");
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
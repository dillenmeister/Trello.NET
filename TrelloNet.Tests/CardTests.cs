using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using ExpectedObjects;
using NUnit.Framework;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class CardTests : TrelloTestBase
	{
		private readonly ICardId _welcomeToTrelloCardWritable = new CardId("4f41e4803374646b5c74bdb0");
		private readonly IBoardId _welcomeBoardWritable = new BoardId("4f41e4803374646b5c74bd69");
		private readonly IListId _basicsListWritable = new ListId("4f41e4803374646b5c74bd61");
		private readonly IListId _intermediateListWritable = new ListId("4f41e4803374646b5c74bd62");
		private readonly IMemberId _memberTrello = new MemberId("4e6a7fad05d98b02ba00845c");
		private const string CardWithCheckList = "4f41e4803374646b5c74bdbe";

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
		public void WithId_CardWithCheckList_HasOneCheckList()
		{
			var card = _trelloReadWrite.Cards.WithId(CardWithCheckList);

			Assert.That(card.Checklists.Count(), Is.EqualTo(1));			
		}

        [Test]
        public void WithId_CardWithCheckList_HasChecklistWithThreeItemsAndtheFirstItemIsChecked()
        {
            var card = _trelloReadWrite.Cards.WithId(CardWithCheckList);

            Assert.That(card.Checklists.First().CheckItems.Count, Is.EqualTo(3));
            Assert.That(card.Checklists.First().CheckItems.ElementAt(0).Checked, Is.EqualTo(true));
            Assert.That(card.Checklists.First().CheckItems.ElementAt(1).Checked, Is.EqualTo(false));
            Assert.That(card.Checklists.First().CheckItems.ElementAt(2).Checked, Is.EqualTo(false));
        }

		[Test]
		public void WithId_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Cards.WithId(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "id"));
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
		public void ForBoard_WelcomeBoard_Returns18Cards()
		{
			var cards = _trelloReadOnly.Cards.ForBoard(new BoardId(Constants.WelcomeBoardId));

			Assert.That(cards.Count(), Is.EqualTo(18));
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
		public void Scenario_ChangeDueDate()
		{
			_trelloReadWrite.Cards.ChangeDueDate(_welcomeToTrelloCardWritable, new DateTime(2015, 01, 01, 0, 0, 0, DateTimeKind.Utc));

			var cardAfterChange = GetWelcomeToTrelloCard();

			Assert.That(cardAfterChange.Due, Is.EqualTo(new DateTime(2015, 01, 01, 0, 0, 0, DateTimeKind.Utc)));

			_trelloReadWrite.Cards.ChangeDueDate(_welcomeToTrelloCardWritable, null);
		}

		[Test]
		public void ChangeDueDate_BugIncorrectSerializationOfDatesForCertainCultures()
		{
			var cultureBefore = Thread.CurrentThread.CurrentCulture;
			Thread.CurrentThread.CurrentCulture = new CultureInfo("nl-BE");

			_trelloReadWrite.Cards.ChangeDueDate(_welcomeToTrelloCardWritable, new DateTime(2012, 03, 09, 0, 0, 0, DateTimeKind.Utc));

			Thread.CurrentThread.CurrentCulture = cultureBefore;

			var cardAfterChange = GetWelcomeToTrelloCard();

			Assert.That(cardAfterChange.Due, Is.EqualTo(new DateTime(2012, 03, 09, 0, 0, 0, DateTimeKind.Utc)));			
		}

		[Test]
		public void Update_BugIncorrectSerializationOfDatesForCertainCultures()
		{
			var cultureBefore = Thread.CurrentThread.CurrentCulture;
			Thread.CurrentThread.CurrentCulture = new CultureInfo("nl-BE");

			var card = GetWelcomeToTrelloCard();
			card.Due = new DateTime(2012, 03, 09, 0, 0, 0, DateTimeKind.Utc);
			_trelloReadWrite.Cards.Update(card);

			Thread.CurrentThread.CurrentCulture = cultureBefore;

			var cardAfterChange = GetWelcomeToTrelloCard();

			Assert.That(cardAfterChange.Due, Is.EqualTo(new DateTime(2012, 03, 09, 0, 0, 0, DateTimeKind.Utc)));
		}

		[Test]
		public void Scenario_AddAndDelete()
		{
			var card = _trelloReadWrite.Cards.Add(new NewCard("A new card", _basicsListWritable) { Desc = "The card description" });

			Assert.That(card.Desc, Is.EqualTo("The card description"));
			Assert.That(card.Name, Is.EqualTo("A new card"));
			Assert.That(card.IdBoard, Is.EqualTo(_welcomeBoardWritable.GetBoardId()));
			Assert.That(card.IdList, Is.EqualTo(_basicsListWritable.GetListId()));

			_trelloReadWrite.Cards.Delete(card);

			var deletedCard = _trelloReadWrite.Cards.WithId(card.Id);

			Assert.That(deletedCard, Is.Null);
		}

		[Test]
		public void Scenario_ArchiveAndUnarchive()
		{			
			_trelloReadWrite.Cards.Archive(_welcomeToTrelloCardWritable);

			var archivedCard = _trelloReadWrite.Cards.WithId(_welcomeToTrelloCardWritable.GetCardId());
			Assert.That(archivedCard.Closed, Is.True);

			_trelloReadWrite.Cards.Unarchive(_welcomeToTrelloCardWritable);
			var cardSentToBoard = _trelloReadWrite.Cards.WithId(_welcomeToTrelloCardWritable.GetCardId());

			Assert.That(cardSentToBoard.Closed, Is.False);
		}

		[Test]
		public void Scenario_ChangeNameAndDescription()
		{
			_trelloReadWrite.Cards.ChangeDescription(_welcomeToTrelloCardWritable, "A new description");
			_trelloReadWrite.Cards.ChangeName(_welcomeToTrelloCardWritable, "A new name");

			var changedCard = _trelloReadWrite.Cards.WithId(_welcomeToTrelloCardWritable.GetCardId());

			Assert.That(changedCard.Desc, Is.EqualTo("A new description"));
			Assert.That(changedCard.Name, Is.EqualTo("A new name"));

			_trelloReadWrite.Cards.ChangeDescription(_welcomeToTrelloCardWritable, "");
			_trelloReadWrite.Cards.ChangeName(_welcomeToTrelloCardWritable, "Welcome to Trello!");
		}

		[Test]
		public void Scenario_MoveCardBetweenLists()
		{						
			var from = _basicsListWritable;
			var to = _intermediateListWritable;

			var card = GetWelcomeToTrelloCard();

			Assert.That(card.IdList, Is.Not.EqualTo(to.GetListId()));

			_trelloReadWrite.Cards.Move(card, to);

			var cardAfterMove = _trelloReadWrite.Cards.WithId(card.Id);

			Assert.That(cardAfterMove.IdList, Is.EqualTo(to.GetListId()));

			_trelloReadWrite.Cards.Move(card, from);
		}

		[Test]
		public void Scenario_MoveCardBetweenBoards()
		{
			const string cardToMoveId = "4f41e4803374646b5c74bdbe";
			const string targetBoardId = "5073b5f818b001167c191bf4";
			const string targetListId = "5073b5f818b001167c191bf6";

			_trelloReadWrite.Cards.Move(new CardId(cardToMoveId), new BoardId(targetBoardId), new ListId(targetListId));

			var cardAfterMove = _trelloReadWrite.Cards.WithId(cardToMoveId);

			_trelloReadWrite.Cards.Move(new CardId(cardToMoveId), _welcomeBoardWritable, _basicsListWritable);

			Assert.That(cardAfterMove.IdBoard, Is.EqualTo(targetBoardId));
			Assert.That(cardAfterMove.IdList, Is.EqualTo(targetListId));
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
			var membersForCard = _trelloReadWrite.Members.ForCard(_welcomeToTrelloCardWritable);

			Assert.That(membersForCard.All(m => m.Username != "trello"));

			_trelloReadWrite.Cards.AddMember(_welcomeToTrelloCardWritable, _memberTrello);

			var membersForCardAfterAdd = _trelloReadWrite.Members.ForCard(_welcomeToTrelloCardWritable);

			Assert.That(membersForCardAfterAdd.Any(m => m.Username == "trello"));

			_trelloReadWrite.Cards.RemoveMember(_welcomeToTrelloCardWritable, _memberTrello);

			var membersForCardAfterRemove = _trelloReadWrite.Members.ForCard(_welcomeToTrelloCardWritable);

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
		public void Scenario_AddAttachment()
		{
            var card = GetWelcomeToTrelloCard();
            var expectedAttachments = card.Attachments.Count + 1;
            NewAttachment attachment = new NewAttachment("newAttachment", "http://placekitten.com/200/300", null);

            _trelloReadWrite.Cards.AddAttachment(card, attachment);

            var cardAfterAttachment = GetWelcomeToTrelloCard();
            var actualAttachments = cardAfterAttachment.Attachments.Count;

            Assert.That(actualAttachments, Is.EqualTo(expectedAttachments));
		    Assert.IsNotNullOrEmpty(cardAfterAttachment.Attachments.Last().Url);
            //Not testig mimeType because it always seems to come back null
		}

		[Test]
		public void Scenario_AddAndRemoveChecklist()
		{			
			var checklist = _trelloReadWrite.Checklists.Add("a test checklist", _welcomeBoardWritable);

			_trelloReadWrite.Cards.AddChecklist(_welcomeToTrelloCardWritable, checklist);
			var checklistsAfterAdd = _trelloReadWrite.Checklists.ForCard(_welcomeToTrelloCardWritable);
			Assert.That(checklistsAfterAdd.Any(c => c.Id == checklist.Id));

			_trelloReadWrite.Cards.RemoveChecklist(_welcomeToTrelloCardWritable, checklist);
			var checklistsAfterRemove = _trelloReadWrite.Checklists.ForCard(_welcomeToTrelloCardWritable);
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
			card.Due = new DateTime(2015, 02, 03, 0, 0, 0, DateTimeKind.Utc);			

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
			Assert.That(cardAfterUpdate.Due, Is.EqualTo(new DateTime(2015, 02, 03, 0, 0, 0, DateTimeKind.Utc)));
		}

		[Test]
		public void Scenario_ChangeNameOfChecklistItem()
		{
			var card = new CardId(CardWithCheckList);
			var checklist = _trelloReadWrite.Checklists.ForCard(card).First();

			_trelloReadWrite.Cards.ChangeCheckItemName(card, checklist, checklist.CheckItems.First(), "A changed name");

			var checklistAfterUpdate = _trelloReadWrite.Checklists.ForCard(card).First();

			_trelloReadWrite.Cards.ChangeCheckItemName(card, checklist, checklist.CheckItems.First(), "Make your own boards");

			Assert.That(checklistAfterUpdate.CheckItems.First().Name, Is.EqualTo("A changed name"));
		}

        [Test]
        public void Scenario_ChangeStateOfChecklistItem()
        {
            var card = _trelloReadWrite.Cards.WithId(CardWithCheckList);
            Assert.That(card.Checklists.First().CheckItems.First().Checked, Is.EqualTo(true));
            var checklist = _trelloReadWrite.Checklists.ForCard(card).First();

            _trelloReadWrite.Cards.ChangeCheckItemState(card, checklist, checklist.CheckItems.First(), false);

            var cardAfterUpdate = _trelloReadWrite.Cards.WithId(CardWithCheckList);

            _trelloReadWrite.Cards.ChangeCheckItemState(card, checklist, checklist.CheckItems.First(), true);

            Assert.That(cardAfterUpdate.Checklists.First().CheckItems.First().Checked, Is.EqualTo(false));
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
				Throws.InstanceOf<ArgumentException>().With.Matches<ArgumentException>(e => e.ParamName == "id"));
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
				Due = new DateTime(2015, 01, 01, 09, 00, 00),
				Labels = new List<Card.Label>(),
				IdShort = 1,
				Checklists = new List<Card.Checklist>(),
				Url = "https://trello.com/card/welcome-to-trello/4f2b8b4d4f2cb9d16d3684c9/1",	
				Pos = 32768,
				Badges = new Card.CardBadges
				{
					Votes = 1,
					Attachments = 1,
					Comments = 2,
					CheckItems = 0,
					CheckItemsChecked = 0,
					Description = false,
					Due = new DateTime(2015, 01, 01, 09, 00, 00),
					FogBugz = ""
				},
				Attachments = new List<Card.Attachment> 
				{ 
					new Card.Attachment
					{
						Id = "4f6e4ae07f4c6c2b35adb42c",
						IdMember = "4f2b8b464f2cb9d16d368326",
						Name = "Penguins.jpg",
						Url = "https://trello-attachments.s3.amazonaws.com/4f2b8b4d4f2cb9d16d3684c9/4f2b8b4d4f2cb9d16d3684e6/SrQAGJk9EBVFk9sP8NDvyiMzUC8x/Penguins.jpg",
                        MimeType = "image/jpeg",
						Date = DateTime.Parse("2012-03-24 22:29:52.546")
					}
				}
			}.ToExpectedObject();
		}
	}
}
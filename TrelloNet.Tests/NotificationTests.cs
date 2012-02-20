using System;
using System.Linq;
using ExpectedObjects;
using NUnit.Framework;
using TrelloNet.Internal;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class NotificationTests : TrelloTestBase
	{
		[Test]
		public void GetById_Null_Throws()
		{
			Assert.That(() => _readTrello.Notifications.WithId(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "notificationId"));
		}

		[Test]
		public void GetById_TheNotification_ReturnsExpectedNotification()
		{
			var expected = new AddedToCardNotification
			{
				Id = "4f359c4d655ca8cf3f049274",
				Unread = false,
				Date = new DateTime(2012, 02, 10, 23, 38, 05, 248),
				IdMemberCreator = "4ece5a165237e5db06624a2a",
				Data = new AddedToCardNotification.NotificationData
				{
					Board = new BoardName
					{
						Id = "4f2b8b4d4f2cb9d16d3684c9",
						Name = "Welcome Board"
					},
					Card = new CardName
					{
						Id = "4f2b8b4d4f2cb9d16d368506",
						Name = "To learn more tricks, check out the guide."
					}
				}
			}.ToExpectedObject();

			var actual = _readTrello.Notifications.WithId("4f359c4d655ca8cf3f049274");

			expected.ShouldEqual(actual);
		}

		[Test]
		public void GetById_AddedToCardNotification_ReturnsCorrectData()
		{
			var expectedData = new AddedToCardNotification.NotificationData
			{
			    Board = new BoardName
			    {
			        Id = "4f2b8b4d4f2cb9d16d3684c9",
			        Name = "Welcome Board"
			    },
			    Card = new CardName
			    {
			        Id = "4f2b8b4d4f2cb9d16d368506",
			        Name = "To learn more tricks, check out the guide."
			    }
			}.ToExpectedObject();

			var actual = (AddedToCardNotification)_readTrello.Notifications.WithId("4f359c4d655ca8cf3f049274");

			expectedData.ShouldEqual(actual.Data);			
		}

		[Test]
		public void GetById_RemovedFromCardNotification_ReturnsCorrectData()
		{
			var expectedData = new RemovedFromCardNotification.NotificationData
			{
				Board = new BoardName
				{
					Id = "4f2b8b4d4f2cb9d16d3684c9",
					Name = "Welcome Board"
				},
				Card = new CardName
				{
					Id = "4f2b8b4d4f2cb9d16d368506",
					Name = "To learn more tricks, check out the guide."
				}
			}.ToExpectedObject();

			var actual = (RemovedFromCardNotification)_readTrello.Notifications.WithId("4f3f58ee3374646b5c1693d9");

			expectedData.ShouldEqual(actual.Data);
		}

		[Test]
		public void GetById_ChangedCardNotification_ReturnsCorrectData()
		{
			var expectedData = new ChangeCardNotification.NotificationData
			{
				Board = new BoardName
				{
					Id = "4f2b8b4d4f2cb9d16d3684c9",
					Name = "Welcome Board"
				},
				Card = new CardName
				{
					Id = "4f2b8b4d4f2cb9d16d3684e6",
					Name = "Welcome to Trello!"
				}
			}.ToExpectedObject();

			var actual = (ChangeCardNotification)_readTrello.Notifications.WithId("4f3f58c53374646b5c168e43");

			expectedData.ShouldEqual(actual.Data);
		}

		[Test]
		public void GetById_InvitedToBoardNotification_ReturnsCorrectData()
		{
			var expectedData = new InvitedToBoardNotification.NotificationData
			{
				Board = new BoardName
				{
					Id = "4f3f548a57189443042c49e1",
					Name = "Another test board"
				}
			}.ToExpectedObject();

			var actual = (InvitedToBoardNotification)_readTrello.Notifications.WithId("4f3f5497b821cb1a440044c0");

			expectedData.ShouldEqual(actual.Data);
		}

		[Test]
		public void GetById_ClosedBoardNotification_ReturnsCorrectData()
		{
			var expectedData = new CloseBoardNotification.NotificationData
			{
				Board = new BoardName
				{
					Id = "4f3f548a57189443042c49e1",
					Name = "Another test board"
				}
			}.ToExpectedObject();

			var actual = (CloseBoardNotification)_readTrello.Notifications.WithId("4f3f5c063cf351b24302108e");

			expectedData.ShouldEqual(actual.Data);
		}

		[Test]
		public void GetById_CommentCardNotification_ReturnsCorrectData()
		{
			var expectedData = new CommentCardNotification.NotificationData
			{
				Board = new BoardName
				{
					Id = "4f2b8b4d4f2cb9d16d3684c9",
					Name = "Welcome Board"
				},
				Card = new CardName
				{
					Id = "4f2b8b4d4f2cb9d16d3684e6",
					Name = "Welcome to Trello!"
				},
				Text = "A test comment"
			}.ToExpectedObject();

			var actual = (CommentCardNotification)_readTrello.Notifications.WithId("4f3f5d073cf351b243024181");

			expectedData.ShouldEqual(actual.Data);
		}

		[Test]
		public void GetById_MentionedOnCardNotification_ReturnsCorrectData()
		{
			var expectedData = new MentionedOnCardNotification.NotificationData
			{
				Board = new BoardName
				{
					Id = "4f2b8b4d4f2cb9d16d3684c9",
					Name = "Welcome Board"
				},
				Card = new CardName
				{
					Id = "4f2b8b4d4f2cb9d16d3684e6",
					Name = "Welcome to Trello!"
				},
				Text = "Hej @trellnettestuser"
			}.ToExpectedObject();

			var actual = (MentionedOnCardNotification)_readTrello.Notifications.WithId("4f3f5fae7eac8802052d559a");

			expectedData.ShouldEqual(actual.Data);
		}

		[Test]
		public void GetByMember_Me_ReturnsNotifications()
		{
			var notifications = _readTrello.Notifications.ForMe();

			Assert.That(notifications.Count(), Is.GreaterThan(1));
		}

		[Test]
		public void GetByMember_MeAndUnread_ReturnsNoNotifications()
		{
			var notifications = _readTrello.Notifications.ForMe(readFilter: ReadFilter.Unread);

			Assert.That(notifications.Count(), Is.EqualTo(0));
		}

		[Test]
		public void GetByMember_MeAndRead_ReturnsNotifications()
		{
			var notifications = _readTrello.Notifications.ForMe(readFilter: ReadFilter.Read);

			Assert.That(notifications.Count(), Is.GreaterThan(1));
		}

		[Test]
		public void GetByMember_MeAndAddedToCard_ReturnsTwoNotifications()
		{
			var notifications = _readTrello.Notifications.ForMe(types: new[] { NotificationType.AddedToCard });

			Assert.That(notifications.Count(), Is.EqualTo(2));
		}

		[Test]
		public void GetByMember_MeAndCloseBoard_ReturnsOneNotifications()
		{
			var notifications = _readTrello.Notifications.ForMe(types: new[] { NotificationType.CloseBoard });

			Assert.That(notifications.Count(), Is.EqualTo(1));
		}

		[Test]
		public void GetByMember_MeAndPaging_ReturnsOneNotification()
		{
			var notifications = _readTrello.Notifications.ForMe(paging: new Paging(1, 1));

			Assert.That(notifications.Count(), Is.EqualTo(1));
		}
	}
}
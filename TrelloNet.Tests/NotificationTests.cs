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
		public void WithId_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Notifications.WithId(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "id"));
		}

		[Test]
		public void WithId_TheNotification_ReturnsExpectedNotification()
		{
			var expected = new AddedToCardNotification
			{
				Id = "4f359c4d655ca8cf3f049274",
				Unread = false,
				Date = new DateTime(2012, 02, 10, 22, 38, 05, 248),
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

			var actual = _trelloReadOnly.Notifications.WithId("4f359c4d655ca8cf3f049274");

			expected.ShouldEqual(actual);
		}

		[Test]
		public void WithId_AddedToCardNotification_ReturnsCorrectData()
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

			var actual = (AddedToCardNotification)_trelloReadOnly.Notifications.WithId("4f359c4d655ca8cf3f049274");

			expectedData.ShouldEqual(actual.Data);			
		}

		[Test]
		public void WithId_RemovedFromCardNotification_ReturnsCorrectData()
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

			var actual = (RemovedFromCardNotification)_trelloReadOnly.Notifications.WithId("4f3f58ee3374646b5c1693d9");

			expectedData.ShouldEqual(actual.Data);
		}

		[Test]
		public void WithId_ChangedCardNotification_ReturnsCorrectData()
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

			var actual = (ChangeCardNotification)_trelloReadOnly.Notifications.WithId("4f3f58c53374646b5c168e43");

			expectedData.ShouldEqual(actual.Data);
		}

		[Test]
		public void WithId_InvitedToBoardNotification_ReturnsCorrectData()
		{
			var expectedData = new InvitedToBoardNotification.NotificationData
			{
				Board = new BoardName
				{
					Id = "4f3f548a57189443042c49e1",
					Name = "Another test board"
				}
			}.ToExpectedObject();

			var actual = (InvitedToBoardNotification)_trelloReadOnly.Notifications.WithId("4f3f5497b821cb1a440044c0");

			expectedData.ShouldEqual(actual.Data);
		}

		[Test]
		public void WithId_ClosedBoardNotification_ReturnsCorrectData()
		{
			var expectedData = new CloseBoardNotification.NotificationData
			{
				Board = new BoardName
				{
					Id = "4f3f548a57189443042c49e1",
					Name = "Another test board"
				}
			}.ToExpectedObject();

			var actual = (CloseBoardNotification)_trelloReadOnly.Notifications.WithId("4f3f5c063cf351b24302108e");

			expectedData.ShouldEqual(actual.Data);
		}

		[Test]
		public void WithId_CommentCardNotification_ReturnsCorrectData()
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

			var actual = (CommentCardNotification)_trelloReadOnly.Notifications.WithId("4f3f5d073cf351b243024181");

			expectedData.ShouldEqual(actual.Data);
		}

		[Test]
		public void WithId_MentionedOnCardNotification_ReturnsCorrectData()
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

			var actual = (MentionedOnCardNotification)_trelloReadOnly.Notifications.WithId("4f3f5fae7eac8802052d559a");

			expectedData.ShouldEqual(actual.Data);
		}

		[Test]
		public void ForMe_ReturnsNotifications()
		{
			var notifications = _trelloReadOnly.Notifications.ForMe();

			Assert.That(notifications.Count(), Is.GreaterThan(1));
		}

		[Test]
		public void ForMe_Unread_ReturnsNoNotifications()
		{
			var notifications = _trelloReadOnly.Notifications.ForMe(readFilter: ReadFilter.Unread);

			Assert.That(notifications.Count(), Is.EqualTo(0));
		}

		[Test]
		public void ForMe_Read_ReturnsNotifications()
		{
			var notifications = _trelloReadOnly.Notifications.ForMe(readFilter: ReadFilter.Read);

			Assert.That(notifications.Count(), Is.GreaterThan(1));
		}

		[Test]
		public void ForMe_AddedToCard_ReturnsTwoNotifications()
		{
			var notifications = _trelloReadOnly.Notifications.ForMe(types: new[] { NotificationType.AddedToCard });

			Assert.That(notifications.Count(), Is.EqualTo(2));
		}

		[Test]
		public void ForMe_CloseBoard_ReturnsOneNotifications()
		{
			var notifications = _trelloReadOnly.Notifications.ForMe(types: new[] { NotificationType.CloseBoard });

			Assert.That(notifications.Count(), Is.EqualTo(1));
		}

		[Test]
		public void ForMe_Paging_ReturnsOneNotification()
		{
			var notifications = _trelloReadOnly.Notifications.ForMe(paging: new Paging(1, 0));

			Assert.That(notifications.Count(), Is.EqualTo(1));
		}
	}
}
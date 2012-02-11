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
			Assert.That(() => _trello.Notifications.GetById(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "notificationId"));
		}

		[Test]
		public void GetById_TheNotification_ReturnsExpectedNotification()
		{
			var expected = new Notification
			{
				Id = "4f359c4d655ca8cf3f049274",
				Unread = false,
				Date = new DateTime(2012, 02, 10, 23, 38, 05, 248),
				IdMemberCreator = "4ece5a165237e5db06624a2a",
				Type = NotificationType.AddedToCard
			};

			var actual = _trello.Notifications.GetById("4f359c4d655ca8cf3f049274");

			Assert.That(actual.Id, Is.EqualTo(expected.Id));
			Assert.That(actual.Unread, Is.EqualTo(expected.Unread));
			Assert.That(actual.Date, Is.EqualTo(expected.Date));
			Assert.That(actual.IdMemberCreator, Is.EqualTo(expected.IdMemberCreator));
			Assert.That(actual.Type, Is.EqualTo(expected.Type));
			Assert.That(actual.Data.board.id.ToString(), Is.EqualTo("4f2b8b4d4f2cb9d16d3684c9"));
		}

		[Test]
		public void GetByMember_Me_ReturnsOneNotification()
		{
			var notifications = _trello.Notifications.GetByMe();

			Assert.That(notifications.Count(), Is.EqualTo(1));
		}

		[Test]
		public void GetByMember_MeAndUnread_ReturnsNoNotifications()
		{
			var notifications = _trello.Notifications.GetByMe(readFilter: ReadFilter.Unread);

			Assert.That(notifications.Count(), Is.EqualTo(0));
		}

		[Test]
		public void GetByMember_MeAndRead_ReturnsOneNotification()
		{
			var notifications = _trello.Notifications.GetByMe(readFilter: ReadFilter.Read);

			Assert.That(notifications.Count(), Is.EqualTo(1));
		}

		[Test]
		public void GetByMember_MeAndAddedToCard_ReturnsOneNotification()
		{
			var notifications = _trello.Notifications.GetByMe(types: new[] { NotificationType.AddedToCard });

			Assert.That(notifications.Count(), Is.EqualTo(1));
		}

		[Test]
		public void GetByMember_MeAndCloseBoard_ReturnsNoNotifications()
		{
			var notifications = _trello.Notifications.GetByMe(types: new[] { NotificationType.CloseBoard });

			Assert.That(notifications.Count(), Is.EqualTo(0));
		}

		[Test]
		public void GetByMember_MeAndPaging_ReturnsOneNotification()
		{
			var notifications = _trello.Notifications.GetByMe(paging: new Paging(1, 1));

			Assert.That(notifications.Count(), Is.EqualTo(1));
		}
	}
}
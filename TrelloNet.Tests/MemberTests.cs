using System;
using System.Linq;
using ExpectedObjects;
using NUnit.Framework;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class MemberTests : TrelloTestBase
	{
		[Test]
		public void GetMe_Always_ReturnsTheMemberMe()
		{
			var expectedMe = CreateExpectedMemberMe();

			var actualMe = _readTrello.Members.Me();

			expectedMe.ShouldEqual(actualMe);
		}

		[Test]
		public void GetById_Trello_ReturnsTheMemberTrello()
		{
			var expectedMember = CreateExpectedMemberTrello();

			var actualMember = _readTrello.Members.WithId("trello");

			expectedMember.ShouldEqual(actualMember);
		}

		[Test]
		public void GetById_IdOfTrello_ReturnsTheMemberTrello()
		{
			var expectedMember = CreateExpectedMemberTrello();

			var actualMember = _readTrello.Members.WithId("4e6a7fad05d98b02ba00845c");

			expectedMember.ShouldEqual(actualMember);
		}

		[Test]
		public void GetById_NonExistingMember_ReturnsNull()
		{
			var member = _readTrello.Members.WithId("nonexistingmember123");

			Assert.That(member, Is.Null);
		}

		[Test]
		public void GetById_Null_Throws()
		{
			Assert.That(() => _readTrello.Members.WithId(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "memberIdOrUsername"));
		}

		[Test]
		public void GetByCard_WelcomeCardOfTheWelcomeBoard_ReturnsMeOnly()
		{
			var members = _readTrello.Members.ForCard(new CardId(Constants.WelcomeCardOfTheWelcomeBoardId));

			Assert.That(members.Count(), Is.EqualTo(1));
			Assert.That(members.First().Id, Is.EqualTo(Constants.MeId));
		}

		[Test]
		public void GetByCard_WelcomeCardOfTheWelcomeBoard_AllFieldsOfMemberAreMapped()
		{
			var expectedMember = CreateExpectedMemberMe();

			var actualMember = _readTrello.Members.ForCard(new CardId(Constants.WelcomeCardOfTheWelcomeBoardId)).Single(m => m.Id == Constants.MeId);

			expectedMember.ShouldEqual(actualMember);
		}

		[Test]
		public void GetByCard_Null_Throws()
		{
			Assert.That(() => _readTrello.Members.ForCard(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "card"));
		}

		[Test]
		public void GetByBoard_WelcomeBoard_ReturnsThreeMembers()
		{
			var members = _readTrello.Members.ForBoard(new BoardId(Constants.WelcomeBoardId));

			Assert.That(members.Count(), Is.EqualTo(3));
		}

		[Test]
		public void GetByBoard_WelcomeBoard_AllFieldsOfMemberAreMapped()
		{
			var expectedMember = CreateExpectedMemberMe();

			var actualMember = _readTrello.Members.ForBoard(new BoardId(Constants.WelcomeBoardId)).Single(m => m.Id == Constants.MeId);

			expectedMember.ShouldEqual(actualMember);
		}

		[Test]
		public void GetByBoard_WelcomeBoardAndFilterOwner_ReturnsOneMember()
		{
			var members = _readTrello.Members.ForBoard(new BoardId(Constants.WelcomeBoardId), MemberFilter.Owners);

			Assert.That(members.Count(), Is.EqualTo(1));
			Assert.That(members.First().Id, Is.EqualTo(Constants.MeId));
		}

		[Test]
		public void GetByBoard_Null_Throws()
		{
			Assert.That(() => _readTrello.Members.ForBoard(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "board"));
		}

		[Test]
		public void GetByOrganization_TestOrganization_ReturnsMe()
		{
			var members = _readTrello.Members.ForOrganization(new OrganizationId(Constants.TestOrganizationId));

			Assert.That(members.Count(), Is.EqualTo(1));
			Assert.That(members.First().Id, Is.EqualTo(Constants.MeId));
		}

		[Test]
		public void GetByOrganization_TestOrganization_AllFieldsOfMemberAreMapped()
		{
			var expectedMember = CreateExpectedMemberMe();

			var actualMember = _readTrello.Members.ForOrganization(new OrganizationId(Constants.TestOrganizationId)).Single(m => m.Id == Constants.MeId);

			expectedMember.ShouldEqual(actualMember);
		}

		[Test]
		public void GetByOrganization_Null_Throws()
		{
			Assert.That(() => _readTrello.Members.ForOrganization(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "organization"));
		}

		private static ExpectedObject CreateExpectedMemberMe()
		{
			return new Member
			{
				FullName = "Trello.NET Test User",
				Bio = "Test bio",
				Url = "https://trello.com/trellnettestuser",
				Username = "trellnettestuser",
				Id = Constants.MeId
			}.ToExpectedObject();
		}

		private static ExpectedObject CreateExpectedMemberTrello()
		{
			return new Member
			{
				FullName = "Trello",
				Bio = string.Empty,
				Url = "https://trello.com/trello",
				Username = "trello",
				Id = "4e6a7fad05d98b02ba00845c"
			}.ToExpectedObject();
		}
	}
}
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

			var actualMe = _trello.Members.GetMe();

			expectedMe.ShouldEqual(actualMe);
		}

		[Test]
		public void GetById_Trello_ReturnsTheMemberTrello()
		{
			var expectedMember = CreateExpectedMemberTrello();

			var actualMember = _trello.Members.GetById("trello");

			expectedMember.ShouldEqual(actualMember);
		}

		[Test]
		public void GetById_IdOfTrello_ReturnsTheMemberTrello()
		{
			var expectedMember = CreateExpectedMemberTrello();

			var actualMember = _trello.Members.GetById("4e6a7fad05d98b02ba00845c");

			expectedMember.ShouldEqual(actualMember);
		}

		[Test]
		public void GetById_NonExistingMember_ReturnsNull()
		{
			var member = _trello.Members.GetById("nonexistingmember123");

			Assert.That(member, Is.Null);
		}

		[Test]
		public void GetById_Null_Throws()
		{
			Assert.That(() => _trello.Members.GetById(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "memberId"));
		}

		[Test]
		public void GetByCard_WelcomeCardOfTheWelcomeBoard_ReturnsMeOnly()
		{
			var members = _trello.Members.GetByCard(new CardId(Constants.WelcomeCardOfTheWelcomeBoardId));

			Assert.That(members.Count(), Is.EqualTo(1));
			Assert.That(members.First().Id, Is.EqualTo(Constants.MeId));
		}

		[Test]
		public void GetByCard_WelcomeCardOfTheWelcomeBoard_AllFieldsOfMemberAreMapped()
		{
			var expectedMember = CreateExpectedMemberMe();

			var actualMember = _trello.Members.GetByCard(new CardId(Constants.WelcomeCardOfTheWelcomeBoardId)).Single(m => m.Id == Constants.MeId);

			expectedMember.ShouldEqual(actualMember);
		}

		[Test]
		public void GetByCard_Null_Throws()
		{
			Assert.That(() => _trello.Members.GetByCard(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "card"));
		}

		[Test]
		public void GetByBoard_WelcomeBoard_ReturnsTwoMembers()
		{
			var members = _trello.Members.GetByBoard(new BoardId(Constants.WelcomeBoardId));

			Assert.That(members.Count(), Is.EqualTo(2));
		}

		[Test]
		public void GetByBoard_WelcomeBoard_AllFieldsOfMemberAreMapped()
		{
			var expectedMember = CreateExpectedMemberMe();

			var actualMember = _trello.Members.GetByBoard(new BoardId(Constants.WelcomeBoardId)).Single(m => m.Id == Constants.MeId);

			expectedMember.ShouldEqual(actualMember);
		}

		[Test]
		public void GetByBoard_WelcomeBoardAndFilterOwner_ReturnsOneMember()
		{
			var members = _trello.Members.GetByBoard(new BoardId(Constants.WelcomeBoardId), MemberFilter.Owners);

			Assert.That(members.Count(), Is.EqualTo(1));
			Assert.That(members.First().Id, Is.EqualTo(Constants.MeId));
		}

		[Test]
		public void GetByBoard_Null_Throws()
		{
			Assert.That(() => _trello.Members.GetByBoard(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "board"));
		}

		[Test]
		public void GetByOrganization_TestOrganization_ReturnsMe()
		{
			var members = _trello.Members.GetByOrganization(new OrganizationId(Constants.TestOrganizationId));

			Assert.That(members.Count(), Is.EqualTo(1));
			Assert.That(members.First().Id, Is.EqualTo(Constants.MeId));
		}

		[Test]
		public void GetByOrganization_TestOrganization_AllFieldsOfMemberAreMapped()
		{
			var expectedMember = CreateExpectedMemberMe();

			var actualMember = _trello.Members.GetByOrganization(new OrganizationId(Constants.TestOrganizationId)).Single(m => m.Id == Constants.MeId);

			expectedMember.ShouldEqual(actualMember);
		}

		[Test]
		public void GetByOrganization_Null_Throws()
		{
			Assert.That(() => _trello.Members.GetByOrganization(null),
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
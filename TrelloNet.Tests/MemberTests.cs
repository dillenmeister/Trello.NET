using System.Linq;
using ExpectedObjects;
using NUnit.Framework;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class MemberTests : TrelloTestBase
	{
		[Test]
		public void Me_ShouldReturnTheMemberMe()
		{
			var expectedMe = CreateExpectedMemberMe();

			var actualMe = _trello.Member(new Me());

			expectedMe.ShouldEqual(actualMe);
		}

		[Test]
		public void UserNameTrello_ShouldReturnTheMemberTrello()
		{
			var expectedMember = CreateExpectedMemberTrello();

			var actualMember = _trello.Member("trello");

			expectedMember.ShouldEqual(actualMember);
		}

		[Test]
		public void IdOfMemberTrello_ShouldReturnTheMemberTrello()
		{
			var expectedMember = CreateExpectedMemberTrello();

			var actualMember = _trello.Member("4e6a7fad05d98b02ba00845c");

			expectedMember.ShouldEqual(actualMember);
		}

		[Test]
		public void NonExistingMemberId_ShouldReturnNull()
		{
			var member = _trello.Member("nonexistingmember123");

			Assert.That(member, Is.Null);
		}

		[Test]
		public void WelcomeCardOfTheWelcomeBoardId_ShouldReturnOnlyMemberMe()
		{
			var members = _trello.Members(new CardId(Constants.WelcomeCardOfTheWelcomeBoardId));

			Assert.That(members.Count(), Is.EqualTo(1));
			Assert.That(members.First().Id, Is.EqualTo(Constants.MeId));
		}

		[Test]
		public void WelcomeCardOfTheWelcomeBoardId_AllFieldsOfMemberShouldBeMapped()
		{
			var expectedMember = CreateExpectedMemberMe();

			var actualMember = _trello.Members(new CardId(Constants.WelcomeCardOfTheWelcomeBoardId)).Single(m => m.Id == Constants.MeId);

			expectedMember.ShouldEqual(actualMember);
		}

		[Test]
		public void WelcomeBoardId_ShouldReturnTwoMembers()
		{
			var members = _trello.Members(new BoardId(Constants.WelcomeBoardId));

			Assert.That(members.Count(), Is.EqualTo(2));
		}

		[Test]
		public void WelcomeBoardId_AllFieldsOfMemberShouldBeMapped()
		{
			var expectedMember = CreateExpectedMemberMe();

			var actualMember = _trello.Members(new BoardId(Constants.WelcomeBoardId)).Single(m => m.Id == Constants.MeId);

			expectedMember.ShouldEqual(actualMember);
		}

		[Test]
		public void WelcomeBoardIdAndFilterOwner_ShouldReturnOneMember()
		{
			var members = _trello.Members(new BoardId(Constants.WelcomeBoardId), MemberFilter.Owners);

			Assert.That(members.Count(), Is.EqualTo(1));
			Assert.That(members.First().Id, Is.EqualTo(Constants.MeId));
		}

		[Test]
		public void TestOrganizationId_ShouldReturnMe()
		{
			var members = _trello.Members(new OrganizationId(Constants.TestOrganizationId));

			Assert.That(members.Count(), Is.EqualTo(1));
			Assert.That(members.First().Id, Is.EqualTo(Constants.MeId));
		}

		[Test]
		public void TestOrganizationId_AllFieldsOfMemberShouldBeMapped()
		{
			var expectedMember = CreateExpectedMemberMe();		

			var actualMember = _trello.Members(new OrganizationId(Constants.TestOrganizationId)).Single(m => m.Id == Constants.MeId);

			expectedMember.ShouldEqual(actualMember);
		}

		private static ExpectedObject CreateExpectedMemberMe()
		{
			var expectedMe = new Member
			{
				FullName = "Trello.NET Test User",
				Bio = "Test bio",
				Url = "https://trello.com/trellnettestuser",
				Username = "trellnettestuser",
				Id = Constants.MeId
			}.ToExpectedObject();
			return expectedMe;
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
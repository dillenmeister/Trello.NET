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
		public void Me_Always_ReturnsTheMemberMe()
		{
			var expectedMe = CreateExpectedMemberMe();

			var actualMe = _trelloReadOnly.Members.Me();

			expectedMe.ShouldEqual(actualMe);
		}

		[Test]
		public void WithId_Trello_ReturnsTheMemberTrello()
		{
			var expectedMember = CreateExpectedMemberTrello();

			var actualMember = _trelloReadOnly.Members.WithId("trello");

			expectedMember.ShouldEqual(actualMember);
		}

		[Test]
		public void WithId_IdOfTrello_ReturnsTheMemberTrello()
		{
			var expectedMember = CreateExpectedMemberTrello();

			var actualMember = _trelloReadOnly.Members.WithId("4e6a7fad05d98b02ba00845c");

			expectedMember.ShouldEqual(actualMember);
		}

		[Test]
		public void WithId_NonExistingMember_ReturnsNull()
		{
			var member = _trelloReadOnly.Members.WithId("nonexistingmember123");

			Assert.That(member, Is.Null);
		}

		[Test]
		public void WithId_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Members.WithId(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "memberIdOrUsername"));
		}

		[Test]
		public void ForCard_WelcomeCardOfTheWelcomeBoard_ReturnsMeOnly()
		{
			var members = _trelloReadOnly.Members.ForCard(new CardId(Constants.WelcomeCardOfTheWelcomeBoardId));

			Assert.That(members.Count(), Is.EqualTo(1));
			Assert.That(members.First().Id, Is.EqualTo(Constants.MeId));
		}

		[Test]
		public void ForCard_WelcomeCardOfTheWelcomeBoard_AllFieldsOfMemberAreMapped()
		{
			var expectedMember = CreateExpectedMemberMe();

			var actualMember = _trelloReadOnly.Members.ForCard(new CardId(Constants.WelcomeCardOfTheWelcomeBoardId)).Single(m => m.Id == Constants.MeId);

			expectedMember.ShouldEqual(actualMember);
		}

		[Test]
		public void ForCard_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Members.ForCard(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "card"));
		}

		[Test]
		public void ForBoard_WelcomeBoard_ReturnsThreeMembers()
		{
			var members = _trelloReadOnly.Members.ForBoard(new BoardId(Constants.WelcomeBoardId));

			Assert.That(members.Count(), Is.EqualTo(3));
		}

		[Test]
		public void ForBoard_WelcomeBoard_AllFieldsOfMemberAreMapped()
		{
			var expectedMember = CreateExpectedMemberMe();

			var actualMember = _trelloReadOnly.Members.ForBoard(new BoardId(Constants.WelcomeBoardId)).Single(m => m.Id == Constants.MeId);

			expectedMember.ShouldEqual(actualMember);
		}

		[Test]
		public void ForBoard_WelcomeBoardAndFilterOwner_ReturnsOneMember()
		{
			var members = _trelloReadOnly.Members.ForBoard(new BoardId(Constants.WelcomeBoardId), MemberFilter.Owners);

			Assert.That(members.Count(), Is.EqualTo(1));
			Assert.That(members.First().Id, Is.EqualTo(Constants.MeId));
		}

		[Test]
		public void ForBoard_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Members.ForBoard(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "board"));
		}

		[Test]
		public void ForOrganization_TestOrganization_ReturnsMe()
		{
			var members = _trelloReadOnly.Members.ForOrganization(new OrganizationId(Constants.TestOrganizationId));

			Assert.That(members.Count(), Is.EqualTo(1));
			Assert.That(members.First().Id, Is.EqualTo(Constants.MeId));
		}

		[Test]
		public void ForOrganization_TestOrganization_AllFieldsOfMemberAreMapped()
		{
			var expectedMember = CreateExpectedMemberMe();

			var actualMember = _trelloReadOnly.Members.ForOrganization(new OrganizationId(Constants.TestOrganizationId)).Single(m => m.Id == Constants.MeId);

			expectedMember.ShouldEqual(actualMember);
		}

		[Test]
		public void ForOrganization_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Members.ForOrganization(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "organization"));
		}

		[Test]
		public void ForToken_TokenOfMe_ReturnsMe()
		{
			var expected = CreateExpectedMemberMe();

			var member = _trelloReadOnly.Members.ForToken("a0f05ce01f11b4dceb1127e244bdc9c45705d44f3ec1b349f3f4a4c306e20fcf");

			expected.ShouldEqual(member);
		}

		[Test]
		public void ToString_EqualsFullName()
		{
			var member = new Member { FullName = "a name" };

			Assert.That(member.ToString(), Is.EqualTo("a name"));
		}

		private static ExpectedObject CreateExpectedMemberMe()
		{
			return new Member
			{
				FullName = "Trello.NET Test User",
				Bio = "Test bio",
				Url = "https://trello.com/trellnettestuser",
				Username = "trellnettestuser",
				Id = Constants.MeId,
				AvatarHash = "076e3caed758a1c18c91a0e9cae3368f",
				UploadedAvatarHash = "076e3caed758a1c18c91a0e9cae3368f",
				GravatarHash = "aa30ae0bdde1b700f8b49d3c568e3e50",
				AvatarSource = "upload",
				Initials = "TU"
			}.ToExpectedObject();
		}

		private static ExpectedObject CreateExpectedMemberTrello()
		{
			return new Member
			{
				FullName = "Trello",
				Bio = null,
				Url = "https://trello.com/trello",
				Username = "trello",
				Id = "4e6a7fad05d98b02ba00845c",
				AvatarHash = "390a29d28d3e4d2de706165c59b33919",
				Initials = "T"
			}.ToExpectedObject();
		}
	}
}
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
			var expectedMe = CreateExpectedMemberCDW();

			var actualMe = _trelloReadOnly.Members.Me();

			expectedMe.ShouldMatch(actualMe);
		}

		[Test]
		public void WithId_Trello_ReturnsTheMemberTrello()
		{
			var expectedMember = CreateExpectedMemberTrello();

			var actualMember = _trelloReadOnly.Members.WithId("trello");

			expectedMember.ShouldMatch(actualMember);
			Assert.That(string.IsNullOrEmpty(actualMember.Bio));
		}

		[Test]
		public void WithId_IdOfTrello_ReturnsTheMemberTrello()
		{
			var expectedMember = CreateExpectedMemberTrello();

			var actualMember = _trelloReadOnly.Members.WithId("4e6a7fad05d98b02ba00845c");

			expectedMember.ShouldMatch(actualMember);
			Assert.That(string.IsNullOrEmpty(actualMember.Bio));						
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
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "idOrUsername"));
		}

		[Test]
		public void ForCard_WelcomeCardOfTheWelcomeBoard_ReturnsMeOnly()
		{
			var members = _trelloReadOnly.Members.ForCard(new CardId("549308215c17338c1ce717c9"));

			Assert.That(members.Count(), Is.EqualTo(1));
			Assert.That(members.First().Id, Is.EqualTo(Constants.MeId));
		}

		[Test]
		public void ForCard_WelcomeCardOfTheWelcomeBoard_AllFieldsOfMemberAreMapped()
		{
			var expectedMember = CreateExpectedMemberCDW();

			var actualMember = _trelloReadOnly.Members.ForCard(new CardId("549308215c17338c1ce717c9")).Single(m => m.Id == Constants.MeId);

			expectedMember.ShouldMatch(actualMember);
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

		[Test, Description("Seems like the invitation expires, so we just check that we get no exception here really")]
		public void InvitedForBoard_WelcomeBoard_Returns1Member()
		{
			var members = _trelloReadOnly.Members.InvitedForBoard(new BoardId(Constants.WelcomeBoardId));

			Assert.That(members.Count(), Is.EqualTo(0));
		}

		[Test]
		public void ForBoard_WelcomeBoard_AllFieldsOfMemberAreMapped()
		{
			var expectedMember = CreateExpectedMemberCDW();

			var actualMember = _trelloReadOnly.Members.ForBoard(new BoardId(Constants.WelcomeBoardId)).Single(m => m.Id == Constants.MeId);

			expectedMember.ShouldMatch(actualMember);
		}

		[Test]
		public void ForBoard_WelcomeBoardAndFilterOwner_ReturnsOneMember()
		{
			var members = _trelloReadOnly.Members.ForBoard(new BoardId(Constants.WelcomeBoardId), MemberFilter.Owners);

			Assert.That(members.Count(), Is.EqualTo(2));
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
			var expectedMember = CreateExpectedMemberCDW();

			var actualMember = _trelloReadOnly.Members.ForOrganization(new OrganizationId(Constants.TestOrganizationId)).Single(m => m.Id == Constants.MeId);

			expectedMember.ShouldMatch(actualMember);
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
			var expected = CreateExpectedMemberCDW();

            var member = _trelloReadOnly.Members.ForToken("4f1ecd33625aab4a75c3d19622b09dbe03e9944a9ec8c97adec2c1e9eaf585c3");

			expected.ShouldMatch(member);
		}

		[Test]
		public void ToString_EqualsFullName()
		{
			var member = new Member { FullName = "a name" };

			Assert.That(member.ToString(), Is.EqualTo("a name"));
		}

		private static ExpectedObject CreateExpectedMemberMe()
		{
			// The reason we return an anonymous type instead of Member is because we dont know what Member.Status will be, and this is a way of not comparing that property
			// Also for some unknown reason GravatarHash returns different results for different API calls. Not important enough to troubleshoot.
			return new
			{
				FullName = "Trello.NET Test User",
				Bio = "Test bio",
				Url = "https://trello.com/trellnettestuser",
				Username = "trellnettestuser",
				Id = Constants.MeId,
				AvatarHash = "076e3caed758a1c18c91a0e9cae3368f",
				Initials = "TU"
				// Status = <-- Ignore status since we don't know
			}.ToExpectedObject();
			
		}

		private static ExpectedObject CreateExpectedMemberTrello()
		{
			return new
			{
				FullName = "Trello",				
				Url = "https://trello.com/trello",
				Username = "trello",
				Id = "4e6a7fad05d98b02ba00845c",
                AvatarHash = "a6cc37f6849928acb91064cf65e61cbc",
				Initials = "T",
				Status = MemberStatus.Disconnected
			}.ToExpectedObject();
		}

        private static ExpectedObject CreateExpectedMemberCDW()
        {
            return new
            {
                FullName = "Christopher Downes-Ward",
                Username = "christopherdownesward",
                Id = "4f9e6801644163614d59db73",
                AvatarHash = "5db13c831c6f50ac6e97217bc77f4034",
                Initials = "CDW"
            }.ToExpectedObject();
        }
	}
}
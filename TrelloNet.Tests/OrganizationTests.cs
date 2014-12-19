using System;
using System.Linq;
using ExpectedObjects;
using NUnit.Framework;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class OrganizationTests : TrelloTestBase
	{
		[Test, Ignore("Bug in Trello API (no tpossible to get hold of description). Nothing we can do at the moment.")]
		public void WithId_TestOrganization_ReturnsTestOrganization()
		{
			var expectedOrganization = CreateExpectedOrganization();

			var actualOrganization = _trelloReadOnly.Organizations.WithId(Constants.TestOrganizationId);

			expectedOrganization.ShouldEqual(actualOrganization);
		}

		[Test]
		public void WithId_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Organizations.WithId(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "idOrName"));
		}

		[Test]
		public void ForMember_Me_ReturnsTestOrganization()
		{
			var expectedOrganization = CreateExpectedOrganization();

			var organizations = _trelloReadOnly.Organizations.ForMe();			

			Assert.That(organizations.Count(), Is.EqualTo(2));
			expectedOrganization.ShouldEqual(organizations.First());					
		}


		[Test]
		public void ForMember_MeAndPublic_ReturnsNoOrganizations()
		{
			var organizations = _trelloReadOnly.Organizations.ForMember(new Me(), OrganizationFilter.Public);

			Assert.That(organizations.Count(), Is.EqualTo(0));
		}

		[Test]
		public void ForMember_MeAndFilterMember_ReturnsTestOrganization()
		{
			var expectedOrganization = CreateExpectedOrganization();

			var organizations = _trelloReadOnly.Organizations.ForMember(new Me(), OrganizationFilter.Members);

			Assert.That(organizations.Count(), Is.EqualTo(2));
			expectedOrganization.ShouldEqual(organizations.First());								
		}

		[Test]
		public void ForMember_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Organizations.ForMember(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "member"));
		}

		[Test]
		public void ForBoard_WelcomeBoard_ReturnsTestOrganization()
		{
			var expectedOrganization = CreateExpectedOrganization();

			var organization = _trelloReadOnly.Organizations.ForBoard(new BoardId(Constants.WelcomeBoardId));

			expectedOrganization.ShouldEqual(organization);
		}

		[Test]
		public void ForBoard_Null_Throws()
		{
			Assert.That(() => _trelloReadOnly.Organizations.ForBoard(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "board"));
		}

		[Test]
		public void ToString_EqualsDisplayName()
		{
			var organization = new Organization { DisplayName = "a name" };

			Assert.That(organization.ToString(), Is.EqualTo("a name"));
		}

		private static ExpectedObject CreateExpectedOrganization()
		{
			return new Organization
			{
                Id = "548b0039e035cf051fb0633d",
                DisplayName = "Test Organisation",
                Name = "testorganisation78",
                Desc = "A tello.Net test organisation",
                Url = "https://trello.com/testorganisation78",
                Website = "http://www.thisisnumero.com",
                LogoHash = "4563880a8fd49bc297bfdb174d7f8cca"
			}.ToExpectedObject();
		}
	}
}
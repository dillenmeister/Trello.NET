using System;
using System.Linq;
using ExpectedObjects;
using NUnit.Framework;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class OrganizationTests : TrelloTestBase
	{
		[Test]
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
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "orgIdOrName"));
		}

		[Test]
		public void ForMember_Me_ReturnsTestOrganization()
		{
			var expectedOrganization = CreateExpectedOrganization();

			var organizations = _trelloReadOnly.Organizations.ForMe();			

			Assert.That(organizations.Count(), Is.EqualTo(1));
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
			var organizations = _trelloReadOnly.Organizations.ForMember(new Me(), OrganizationFilter.Members);

			Assert.That(organizations.Count(), Is.EqualTo(1));
			Assert.That(organizations.First().Id, Is.EqualTo(Constants.TestOrganizationId));
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
				Id = "4f2b94c0c1c87fcb65422344",
				DisplayName = "Trello.NET Test Organization",
				Name = "trellnettestorganization",
				Desc = "organization description",
				Url = "https://trello.com/trellnettestorganization"
			}.ToExpectedObject();
		}
	}
}
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
		public void GetById_TestOrganization_ReturnsTestOrganization()
		{
			var expectedOrganization = new Organization
			{
				Id = "4f2b94c0c1c87fcb65422344",
				DisplayName = "Trello.NET Test Organization",
				Name = "trellnettestorganization",
				Desc = "organization description",
				Url = "https://trello.com/trellnettestorganization"
			}.ToExpectedObject();

			var actualOrganization = _trello.Organizations.WithId(Constants.TestOrganizationId);

			expectedOrganization.ShouldEqual(actualOrganization);
		}

		[Test]
		public void GetById_Null_Throws()
		{
			Assert.That(() => _trello.Organizations.WithId(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "orgIdOrName"));
		}

		[Test]
		public void GetByMember_Me_ReturnsTestOrganization()
		{
			var organizations = _trello.Organizations.ForMember(new Me());

			Assert.That(organizations.Count(), Is.EqualTo(1));
			Assert.That(organizations.First().Id, Is.EqualTo(Constants.TestOrganizationId));					
		}

		[Test]
		public void GetByMember_MeAndPublic_ReturnsNoOrganizations()
		{
			var organizations = _trello.Organizations.ForMember(new Me(), OrganizationFilter.Public);

			Assert.That(organizations.Count(), Is.EqualTo(0));			
		}

		[Test]
		public void GetByMember_MeAndFilterMember_ReturnsTestOrganization()
		{
			var organizations = _trello.Organizations.ForMember(new Me(), OrganizationFilter.Members);

			Assert.That(organizations.Count(), Is.EqualTo(1));
			Assert.That(organizations.First().Id, Is.EqualTo(Constants.TestOrganizationId));					
		}

		[Test]
		public void GetByMember_Null_Throws()
		{
			Assert.That(() => _trello.Organizations.ForMember(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "member"));
		}

		[Test]
		public void GetByBoard_WelcomeBoard_ReturnsTestOrganization()
		{
			var organization = _trello.Organizations.ForBoard(new BoardId(Constants.WelcomeBoardId));
			
			Assert.That(organization.Id, Is.EqualTo(Constants.TestOrganizationId));
		}

		[Test]
		public void GetByBoard_Null_Throws()
		{
			Assert.That(() => _trello.Organizations.ForBoard(null),
				Throws.TypeOf<ArgumentNullException>().With.Matches<ArgumentNullException>(e => e.ParamName == "board"));
		}
	}
}
using System.Linq;
using ExpectedObjects;
using NUnit.Framework;

namespace TrelloNet.Tests
{
	[TestFixture]
	public class OrganizationTests : TrelloTestBase
	{
		[Test]
		public void TestOrganizationId_ShouldReturnTestOrganization()
		{
			var expectedOrganization = new Organization
			{
				Id = "4f2b94c0c1c87fcb65422344",
				DisplayName = "Trello.NET Test Organization",
				Name = "trellnettestorganization",
				Desc = "organization description",
				Url = "https://trello.com/trellnettestorganization"
			}.ToExpectedObject();

			var actualOrganization = _trello.Organization(Constants.TestOrganizationId);

			expectedOrganization.ShouldEqual(actualOrganization);
		}

		[Test]
		public void Me_ShouldReturnTestOrganization()
		{
			var organizations = _trello.Organizations(new Me());

			Assert.That(organizations.Count(), Is.EqualTo(1));
			Assert.That(organizations.First().Id, Is.EqualTo(Constants.TestOrganizationId));					
		}

		[Test]
		public void MeAndFilterPublic_ShouldReturnNoOrganizations()
		{
			var organizations = _trello.Organizations(new Me(), OrganizationFilter.Public);

			Assert.That(organizations.Count(), Is.EqualTo(0));			
		}

		[Test]
		public void MeAndFilterMember_ShouldReturnTestOrganization()
		{
			var organizations = _trello.Organizations(new Me(), OrganizationFilter.Members);

			Assert.That(organizations.Count(), Is.EqualTo(1));
			Assert.That(organizations.First().Id, Is.EqualTo(Constants.TestOrganizationId));					
		}

		[Test]
		public void WelcomeBoardId_ShouldReturnTestOrganization()
		{
			var organization = _trello.Organization(new BoardId(Constants.WelcomeBoardId));
			
			Assert.That(organization.Id, Is.EqualTo(Constants.TestOrganizationId));
		}
	}
}
namespace TrelloNet.Internal
{
	internal class OrganizationsWithIdRequest : OrganizationsRequest
	{
		public OrganizationsWithIdRequest(string orgIdOrName) : base(orgIdOrName)
		{			
		}
	}
}
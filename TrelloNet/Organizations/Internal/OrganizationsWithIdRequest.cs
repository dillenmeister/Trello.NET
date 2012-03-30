namespace TrelloNet.Internal
{
	internal class OrganizationsWithIdRequest : OrganizationsRequest
	{
		public OrganizationsWithIdRequest(string orgIdOrName) : base(orgIdOrName)
		{
			// Bug in Trello API: We have to ask for both desc and description.
			AddParameter("fields", "name,displayName,url,desc,description");
		}
	}
}
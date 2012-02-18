namespace TrelloNet
{
	public class OrganizationName : IOrganizationId
	{
		public string Id { get; set; }
		public string Name { get; set; }

		public string GetOrganizationId()
		{
			return Id;
		}
	}
}
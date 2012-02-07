namespace TrelloNet
{
	public class OrganizationId : IOrganizationId
	{
		private readonly string _id;

		public OrganizationId(string id)
		{
			_id = id;
		}

		public string GetOrganizationId()
		{
			return _id;
		}
	}
}
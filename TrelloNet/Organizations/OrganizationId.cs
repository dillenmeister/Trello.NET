using TrelloNet.Internal;

namespace TrelloNet
{
	public class OrganizationId : IOrganizationId
	{
		private readonly string _orgIdOrName;

		public OrganizationId(string orgIdOrName)
		{
			Guard.NotNullOrEmpty(orgIdOrName, "orgIdOrName");

			_orgIdOrName = orgIdOrName;
		}

		public string GetOrganizationId()
		{
			return _orgIdOrName;
		}
	}
}
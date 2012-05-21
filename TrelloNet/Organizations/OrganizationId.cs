using TrelloNet.Internal;

namespace TrelloNet
{
	public class OrganizationId : IOrganizationId
	{
		private readonly string _idOrName;

		public OrganizationId(string idOrName)
		{
			Guard.NotNullOrEmpty(idOrName, "idOrName");

			_idOrName = idOrName;
		}

		public string IdOrName
		{
			get { return _idOrName; }
		}

		public string GetOrganizationId()
		{
			return IdOrName;
		}
	}
}
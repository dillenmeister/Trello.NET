namespace TrelloNet
{
	public class Organization : IOrganizationId
	{
		public string Id { get; set; }
		public string DisplayName { get; set; }
		public string Name { get; set; }
		public string Desc { get; set; }
		public string Url { get; set; }
		public string Website { get; set; }

		public string GetOrganizationId()
		{
			return Id;
		}

		public override string ToString()
		{
			return DisplayName;
		}
	}
}
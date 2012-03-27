namespace TrelloNet
{
	public class UpdateOrganizationAction : Action
	{
		public ActionData Data { get; set; }

		public class ActionData
		{
			public OrganizationNameAndDescription Organization { get; set; }

			public OldDescription Old { get; set; }
		}
	}
}
namespace TrelloNet
{
    public class UpdateOrganizationAction : Action
    {
        public UpdateOrganizationAction()
        {
            Data = new ActionData();
        }

        public ActionData Data { get; set; }

        public class ActionData : IUpdateData
        {
            public OrganizationName Organization { get; set; }

            public Old Old { get; set; }
        }
    }
}
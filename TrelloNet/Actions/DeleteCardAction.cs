namespace TrelloNet
{
    public class DeleteCardAction : Action
    {
        public DeleteCardAction()
        {
            Data = new ActionData();
        }

        public ActionData Data { get; set; }

        public class ActionData : IUpdateData
        {
            public BoardName Board { get; set; }
            public ListName List { get; set; }
            public CardName Card { get; set; }

            // unused
            public Old Old { get; set; }
        }
    }
}

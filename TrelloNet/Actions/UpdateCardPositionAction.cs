namespace TrelloNet
{
    public class UpdateCardPositionAction : Action
    {
        public UpdateCardPositionAction()
        {
            Data = new ActionData();
        }

        public ActionData Data { get; set; }

        public class ActionData : IUpdateData
        {
            public BoardName Board { get; set; }
            public CardName Card { get; set; }

            public Old Old { get; set; }
        }

        public class CardName : TrelloNet.CardName
        {
            public double Pos { get; set; }
        }
    }
}
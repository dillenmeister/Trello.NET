namespace TrelloNet
{
	public class AddAttachmentToCardAction : Action
	{
		public ActionData Data { get; set; }

		public class ActionData
		{
			public BoardName Board { get; set; }
			public CardName Card { get; set; }
			public AttachmentLink Attachment { get; set; }
		}
	}
}
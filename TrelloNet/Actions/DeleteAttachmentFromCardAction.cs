namespace TrelloNet
{
	public class DeleteAttachmentFromCardAction : Action
	{
		public ActionData Data { get; set; }

		public class ActionData
		{
			public BoardName Board { get; set; }
			public CardName Card { get; set; }
			public AttachmentName Attachment { get; set; }
		}
	}
}
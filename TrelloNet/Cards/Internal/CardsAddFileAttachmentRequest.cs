using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsAddFileAttachmentRequest : CardsRequest
	{
		public CardsAddFileAttachmentRequest(ICardId card, FileAttachment attachment)
			: base(card, "attachments", Method.POST)
		{
			Guard.NotNull(attachment, "attachment");
			Guard.NotNullOrEmpty("attachment.FilePath", attachment.FilePath);

			if (!string.IsNullOrEmpty(attachment.Name))
			{
				Guard.LengthBetween(attachment.Name, 0, 256, "attachment.Name");
				AddParameter("name", attachment.Name);
			}

			AddFile("file", attachment.FilePath);
		}
	}
}
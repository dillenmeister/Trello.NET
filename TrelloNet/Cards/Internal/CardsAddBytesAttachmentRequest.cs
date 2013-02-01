using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsAddBytesAttachmentRequest : CardsRequest
	{
		public CardsAddBytesAttachmentRequest(ICardId card, BytesAttachment attachment)
			: base(card, "attachments", Method.POST)
		{
			Guard.NotNull(attachment, "attachment");
			Guard.NotNull(attachment.Contents, "attachment.Contents");
			Guard.LengthBetween(attachment.Name, 0, 256, "attachment.Name");

			AddParameter("name", attachment.Name);			
			AddFile("file", attachment.Contents, attachment.FileName ?? attachment.Name);
		}
	}
}
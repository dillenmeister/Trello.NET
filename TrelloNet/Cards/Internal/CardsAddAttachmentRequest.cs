using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsAddAttachmentRequest : CardsRequest
	{
		public CardsAddAttachmentRequest(ICardId card, NewAttachment attachment)
			: base(card, "attachments", Method.POST)
		{
            if (!string.IsNullOrEmpty(attachment.Name))
    			AddParameter("name", attachment.Name);
            if (!string.IsNullOrEmpty(attachment.Url))
    			AddParameter("url", attachment.Url);
            if (!string.IsNullOrEmpty(attachment.MimeType))
    			AddParameter("mimeType", attachment.MimeType);
		}
	}
}
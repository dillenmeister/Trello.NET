using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsAddUrlAttachmentRequest : CardsRequest
	{
		public CardsAddUrlAttachmentRequest(ICardId card, UrlAttachment attachment)
			: base(card, "attachments", Method.POST)
		{
			Guard.NotNull(attachment, "attachment");
			Guard.NotNullOrEmpty(attachment.Url, "attachment.Url");

			if (!string.IsNullOrEmpty(attachment.Name))
			{
				Guard.LengthBetween(attachment.Name, 0, 256, "attachment.Name");
				AddParameter("name", attachment.Name);
			}

			AddParameter("url", attachment.Url);
		}
	}
}
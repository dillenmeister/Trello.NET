using RestSharp;

namespace TrelloNet.Internal
{
	internal class CardsAddAttachmentRequest : CardsRequest
	{
		public CardsAddAttachmentRequest(ICardId card, Card.Attachment attachment)
			: base(card, "attachments", Method.POST)
		{
			AddParameter("url", attachment.Url);
		}
	}
}